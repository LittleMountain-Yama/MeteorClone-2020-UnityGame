using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IReminder, IUpdate
{
    private PlayerModel _m;
    private Memento<PlayerSnapshot> _memento = new Memento<PlayerSnapshot>();// MEMENTO
    public int currentLife;

    #region Commands
    Right right;
    Left left;
    Down down;
    Up up;
    private Rotation rot;

    Shoot shoot;
    ChangeWeapon changeW;
    Detonate det;
    #endregion

    public void Awake()
    {
        _m = GetComponent<PlayerModel>();

        //MyA1-P2
        #region Commands
        right = new Right(transform);
        left = new Left(transform);
        down = new Down(transform);
        up = new Up(transform);
        rot = new Rotation(transform);

        shoot = new Shoot(GetComponentInChildren<BulletSpawner>());
        changeW = new ChangeWeapon(GetComponentInChildren<BulletSpawner>());

        det = new Detonate();
        #endregion

        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Player_LifeModify, OnPlayerLifeModify);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Player_LifeChange, OnPlayerLifeChange);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Player_Death, OnPlayerDeath);
    }
    public void Start()
    {       
        UpdateManager.Instance.AddToUpdate(this);
        MementoManager.instance.Add(this); // MEMENTO
    }
    //MyA1-P2
    public void OnUpdate()
    {
        Brain();
    }

    void Brain()
    {
        //Checkear code de esto
        rot.Do(_m.speed);

        if (Input.GetKey(KeyCode.D))
        {
            right.Do(_m.speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            left.Do(_m.speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            up.Do(_m.speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            down.Do(_m.speed);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot.Do();
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f || Input.GetKey(KeyCode.E))
        {
            changeW.Do();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            det.Do();
        }
    }

    #region  MementoFunction
    public void MakeSnapshot()
    {
        var snapshot = new PlayerSnapshot();
        snapshot.position = transform.position;
        snapshot.rotation = transform.rotation;
        snapshot.life = currentLife;
        _memento.Record(snapshot);
    }

    public void Rewind()
    {
        if (!_memento.CanRemember()) return;

        var snapshot = _memento.Remember();

        transform.position = snapshot.position;
        transform.rotation = snapshot.rotation;
        EventManager.TriggerEvent(EventManager.EventsType.Event_Player_LifeModify,snapshot.life - currentLife);
    }

    public IEnumerator StartToRecord()
    {
        while (true)
        {
            MakeSnapshot();

            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion

    #region  Events
    void OnPlayerLifeModify(params object[] param)
    {
        var newLife = currentLife + (int)param[0];
        if (newLife > _m.maxLife)
        {
            newLife = _m.maxLife;
        }
        currentLife = newLife;
        EventManager.TriggerEvent(EventManager.EventsType.Event_HUD_Life, currentLife);
    }
    
    void OnPlayerLifeChange(params object[] param)
    {
        var newLife = (int)param[0];
        if (newLife > _m.maxLife)
        {
            newLife = _m.maxLife;
        }
        currentLife = newLife;
        EventManager.TriggerEvent(EventManager.EventsType.Event_HUD_Life, currentLife);
    }

    void OnPlayerDeath(params object[] param)
    {
        if (currentLife <= 0)
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_Game_Lose);
        }
    }
    #endregion
}
