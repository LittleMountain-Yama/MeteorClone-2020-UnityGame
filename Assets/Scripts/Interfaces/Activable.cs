using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//MyA1-P3
public class Activable : IActivable, IUpdate
{
    Proyectile _p;
    public IActivable next { get; set; }

    public bool isDetonable = true, isVisited = false;

    float explosionRadius = 10;
    int id = -11;

    public void OnSpawn(Proyectile p = null)
    {
        _p = p;
        BombManager.Instance.AddToList(this);
        UpdateID();
    }

    public void Activate()
    {
        if (isDetonable)
            Trigger();

        Chain();
    }

    void Trigger()
    {
        if (_p != null)
        {
            Explosion();
        }
        /*else
            Debug.Log("Che, no hay proyectil, xd");*/
    }    

    void Chain()
    {
        var temp = BombManager.Instance.GetBomb(id - 1);
        next = temp;

        if (next != null && next != this)
        {
            TimedExplosion();
        }
        /*else if (next == null )
            Debug.Log("Bomba Null");
        else if (next == this)
            Debug.Log("Me quiero detonar varias veces");*/
    }

    #region Explosion
    void TimedExplosion()
    {
        UpdateManager.Instance.AddToUpdate(this);
    }

    float timer, timerLimit = 0.275f;
    public void OnUpdate()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= timerLimit)
        {
            timer = 0;
            UpdateManager.Instance.RemoveFromUpdate(this);
            next.Activate();
        }
    }

    void Explosion()
    {
        LayerMask mask;
        mask = LayerMask.GetMask("Asteroid");

        Collider2D[] collider = Physics2D.OverlapCircleAll(_p.transform.position, explosionRadius, mask);
        foreach (var item in collider)
        {
            if (item.GetComponent<Asteroid>())
            {
                EventManager.TriggerEvent(EventManager.EventsType.Event_Score_AddScore, 100);
                item.GetComponent<Asteroid>().OnHit();
            }
        }

        int temp = Random.Range(5, 6);
        EventManager.TriggerEvent(EventManager.EventsType.Event_Sound_Trigger, temp);

        _p.OnDeath();
        BombManager.Instance.RemoveFromList(this);
    }
    #endregion

    public void UpdateID(int modifier = 0)
    {
        id = BombManager.Instance.GetCount() + modifier;
        //Debug.Log(id);
    }
}

   
