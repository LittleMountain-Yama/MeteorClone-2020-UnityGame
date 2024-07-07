using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IUpdate, IReminder
{
    float _speed;

    private Sprite _currentSprite;
    IBehaviour _ib;

    private PlayerModel target;

    AsteroidSpawner _as; //Lo que crea el pool y posiciona los asteroides
    SpriteRenderer _sr;
    private BoxCollider2D _bc;


    public float _timeAlive;
    private bool _mementoActive;
    private bool _mementoActive2;
    private bool tempDeath;
    public bool _wasAlive;

    private Memento<AsteroidsSnapshot> _memento = new Memento<AsteroidsSnapshot>();// MEMENTO

    public void Create(float speed, Vector2 bcSize, Vector2 sizeTrans, IBehaviour ib, AsteroidSpawner spawner, string spritePath)
    {
        _speed = speed;
        _currentSprite = Resources.Load<Sprite>(spritePath);
        _sr.sprite = _currentSprite;
        transform.localScale = sizeTrans;
        _bc.size = bcSize;
        _ib = ib;
        _as = spawner;
    }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();
        MementoManager.instance.Add(this); // MEMENTO
        _timeAlive = 0;
    }

    public void OnUpdate()
    {
        if (!_wasAlive && _mementoActive)
        {
            tempDeath = false;
            EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_Count);
            _as.DestroyAsteroid(this);
            TurnOff(this);
            Debug.Log("Volve");
        }
        if (!tempDeath)
        {
            Move();
            TimeAlive();
            _bc.enabled = true;
        }
        else
        {
            _bc.enabled = false;
        }

        if (_mementoActive)
        {
            tempDeath = false;
            _sr.sprite = _currentSprite;
        }
    }

    void TimeAlive()
    {
        if (_timeAlive <= 0.2f && !_mementoActive)
        {
            _wasAlive = false;
        }
        else if (_timeAlive > 0.2f && !_mementoActive)
        {
            _wasAlive = true;

        }
        if (_timeAlive < 6 && !_mementoActive)
        {
            _timeAlive += Time.deltaTime;
        }

    }

    void Move()
    {
        target = FindObjectOfType<PlayerModel>();
        Vector3 dir = target.transform.position - transform.position;
        dir.z = target.transform.position.z;
        dir.Normalize();
        transform.position += dir * _speed * Time.deltaTime;
    }

    #region Memento
    public void MakeSnapshot()
    {
        var snapshot = new AsteroidsSnapshot();
        snapshot.position = transform.position;
        snapshot.rotation = transform.rotation;
        snapshot.wasAlive = _wasAlive;
        _memento.Record(snapshot);
        _mementoActive = false;
    }

    public void Rewind()
    {
        if (!_memento.CanRemember()) return;

        var snapshot = _memento.Remember();

        transform.position = snapshot.position;
        transform.rotation = snapshot.rotation;
        _wasAlive = snapshot.wasAlive;
        _mementoActive = true;
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

    #region Spawner Functions
    public static void TurnOn(Asteroid a)
    {
        UpdateManager.Instance.AddToUpdate(a);
        a.gameObject.SetActive(true);
    }

    public static void TurnOff(Asteroid a)
    {
        UpdateManager.Instance.RemoveFromUpdate(a);
        a.gameObject.SetActive(false);
    }
    #endregion

    #region Despawning
    private void OnCollisionEnter2D(Collision2D other)
    {
        Proyectile p = other.gameObject.GetComponent<Proyectile>();
        PlayerModel player = other.gameObject.GetComponent<PlayerModel>();
        var c = other.gameObject.layer == 9;

        if (c)
        {
            OnCageHit();
        }

        if (player)
        {
           EventManager.TriggerEvent(EventManager.EventsType.Event_Player_Death);
           EventManager.TriggerEvent(EventManager.EventsType.Event_Player_LifeModify, -1);

            OnHit();
        }

        //Separado por implementacion de interface
        if (p)
        {
           if (p.DidCollision())
           {
               EventManager.TriggerEvent(EventManager.EventsType.Event_Score_AddScore, 100);
               OnHit();
           }
        }
    }

    public void OnHit()
    {
        var val = Random.Range(1, 3);
        _sr.sprite = FlyWeightAsteroid.Default.explosionTable.LoadSprite(val);
        PowerUpSpawning();
        tempDeath = true;
        StartCoroutine(HideAsteroid());
    }

    public void OnCageHit()
    {
        tempDeath = false;
        _timeAlive = 0;
        EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_Count);
        _as.DestroyAsteroid(this);
        TurnOff(this);
    }

    IEnumerator HideAsteroid()
    {
        yield return new WaitForSeconds(0.1f);
        _ib.OnHit(this.transform.position);
        EventManager.TriggerEvent(EventManager.EventsType.Event_Sound_Trigger, FlyWeightAsteroid.Default.sound);
        transform.position = new Vector3(120, 120);
        StartCoroutine(ReturnAsteroid());
        StopCoroutine(HideAsteroid());
    }

    IEnumerator ReturnAsteroid()
    {
        yield return new WaitForSeconds(4.9f);
        if (tempDeath)
        {
            _timeAlive = 0;
            EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_Count);
            tempDeath = false;
            _as.DestroyAsteroid(this);
            TurnOff(this);
            StopCoroutine(ReturnAsteroid());
        }
    }

    public void PowerUpSpawning()
    {
        var val = Random.Range(1, 20);
        var powerup = FlyWeightAsteroid.Default.powerUpTable.LoadPowerUp(val);

        if (powerup != null)
        {
            var p = Instantiate(powerup);
            p.transform.position = this.transform.position;
        }
    }
    #endregion
}