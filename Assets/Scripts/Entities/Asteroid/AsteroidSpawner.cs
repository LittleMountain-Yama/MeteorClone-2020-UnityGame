using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private int _activeAsteroids, _roundAsteroids; //la cantidad de asteroides en pantalla y cuantos van a spawnear esta ronda
    public int activeAsteroids { get { return _activeAsteroids; } }
    public int roundAsteroids { get { return _roundAsteroids; } }

    public Transform waypointFather;
    private Transform[] _waypoints;
    
    //Asteroid spawning
    private Pool<Asteroid> _pool;
    Asteroid prefab;
    
    private int _asteroidID = 0;
    private AsteroidType _currentAsteroid;
    private List<AsteroidType> _asteroids = new List<AsteroidType>();

    private ExplosionTable _et;

    #region SettingUp
    private void Start()
    {
        _pool = new Pool<Asteroid>(Factory, Asteroid.TurnOn, Asteroid.TurnOff, 10, true);

        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Spawner_AsteroidsQuantity, ChangeRound);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Spawner_Count, ChangeCount);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Spawner_Spawn, SpecialSpawning);

        _waypoints = waypointFather.GetComponentsInChildren<Transform>();
        AsteroidAdd();
        
        _et = new ExplosionTable();
    }

    private void Awake()
    {
        prefab = Resources.Load<Asteroid>("Asteroid");
    }
    #endregion

    #region Spawning
    public IEnumerator RoundSpawning()
    {
        //Debug.Log("Spawneando Asteroids");

        while (roundAsteroids > 0)
        {
            int posToSpawn = Random.Range(0, _waypoints.Length); //Posicion en la que va a spawnear

            UpdateAsteroidID(0);
            SpawnAsteroid(_waypoints[posToSpawn].position);

            _roundAsteroids--;

            yield return new WaitForSeconds(0.5f);
        }

        StopCoroutine(RoundSpawning());
    }

    void SpawnAsteroid(Vector3 newPosition)
    {
        var a = _pool.SendFromPool();
        a = new AsteroidBuilder().SetSprite(_currentAsteroid.AskForPath())
                                 .SetSpeed(_currentAsteroid.speed)
                                 .SetSizeBC(_currentAsteroid.sizeBC)
                                 .SetSizeTrans(_currentAsteroid.sizeTrans)
                                 .SetBehaviour(_currentAsteroid.iBehaviour)
                                 .SetSpawner(this)
                                 .Create(a);
        
        a.transform.position = newPosition;
        _activeAsteroids++;
    }
    #endregion

    #region AsteroidChanging
    void AsteroidAdd()
    {
        _asteroids.Add(new AsteroidBig());
        _asteroids.Add(new AsteroidMedium());
        _asteroids.Add(new AsteroidSmall());
    }
    
    void UpdateAsteroidID(params object[] param)
    {
        if ((int)param[0] < _asteroids.Count)
        {
            _asteroidID = (int)param[0];
        }
        else
        {
            _asteroidID = 0;
        }

        //Debug.Log("El asteroID es " + _asteroidID);
        
        UpdateAsteroidType();
    }
    
    void UpdateAsteroidType()
    {
        _currentAsteroid = _asteroids[_asteroidID];
       //Debug.Log("El tipo de asteroide es " + _currentAsteroid.ToString());
    }
    #endregion

    #region Pool Functions
    public Asteroid Factory()
    {
        return Instantiate(prefab);
    }

    public void DestroyAsteroid(Asteroid a)
    {
        _pool.ReturnToPool(a);
    }
    #endregion

    #region  Events
    void ChangeRound(params object[] param)
    {
        _roundAsteroids = (int)param[0]; //Total de enemigos a spawnear        
        StartCoroutine(RoundSpawning());
    }

    void ChangeCount(params object[] param)
    {
        _activeAsteroids-=1;
        
        if (activeAsteroids == 0)
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_Round_Change);
        }
    }

    void SpecialSpawning(params object[] param)
    {
        UpdateAsteroidID((int)param[0]);
        SpawnAsteroid((Vector3)param[1]);
    }
    #endregion
}
