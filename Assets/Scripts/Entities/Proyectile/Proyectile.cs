using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour, IUpdate
{
    float _speed, _lifeTime;
    int _sound;
    bool _isInmortal;
    bool _canColl;
    
    IMove _currentMoveType;
    List<IMove> _moveTypes = new List<IMove>();

    private BoxCollider2D _bc;
    SpriteRenderer _sr;
    BulletSpawner _bs;

    IActivable _act;

    public void Create(float speed, float lifeTime, int sound, int moveID, bool isInmortal, bool canColl, Vector2 sizeBC, Vector2 sizeTrans, IActivable act, BulletSpawner bs, string spritePath)
    {
        _speed = speed;
        _lifeTime = lifeTime;

        _sound = sound;

        _sr.sprite = SpriteLoad(spritePath);

        _isInmortal = isInmortal;

        _canColl = canColl;

        _bc.size = sizeBC;
        transform.localScale = sizeTrans;

        _act = act;
        if (_act != null)
            _act.OnSpawn(this);

        _bs = bs;

        _currentMoveType = _moveTypes[moveID];
        _currentMoveType.SetTransform(this.transform);
        
        EventManager.TriggerEvent(EventManager.EventsType.Event_Sound_Trigger, _sound);
    }
    
    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();

        MoveAdd();
    }

    public void OnUpdate()
    {
        _currentMoveType.Move(_speed);

        if (!_isInmortal)
        {
            Mortality();
        }        
    }

    void MoveAdd()
    {
        _moveTypes.Add(new MoveForward());
        _moveTypes.Add(new MoveStatic(this.gameObject));
        _moveTypes.Add(new MoveSin());
    }

    Sprite SpriteLoad(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    #region DeSpawning
    public void OnDeath()
    {
        _sr.sprite = FlyWeightProyectile.Default.deathAnim;
        _bc.size = new Vector2(0,0);
        StartCoroutine(ReturnProyectile());
    }

    IEnumerator ReturnProyectile()
    {
        yield return new WaitForSeconds(0.09f);
        _bs.DestroyProyectile(this);
        TurnOff(this);
        StopCoroutine(ReturnProyectile());
    }
    
    void Mortality()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            OnDeath();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Proyectile: Chocó");
        Asteroid a = collision.gameObject.GetComponent<Asteroid>();

        //Separado por implementacion con interfaces
        if (a)
        {
            if(_canColl)
            OnDeath();
        }

        //Si se choca con el borde del mapa
        if (collision.gameObject.layer == 8)
            OnDeath();
    }
    #endregion

    #region Spawner Functions
    public static void TurnOn(Proyectile e)
    {
        UpdateManager.Instance.AddToUpdate(e);
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Proyectile e)
    {
        UpdateManager.Instance.RemoveFromUpdate(e);
        e.gameObject.SetActive(false);
    }
    #endregion

    //test
    public bool DidCollision()
    {
        return _canColl;
    }
}
