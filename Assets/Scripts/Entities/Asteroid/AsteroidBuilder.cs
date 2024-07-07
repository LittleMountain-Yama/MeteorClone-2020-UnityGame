using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBuilder : MonoBehaviour
{
    float _speed;
    string _spritePath;
    Vector2 _sizeBC, _sizeTrans;

    IBehaviour _ib;
    
    private PlayerModel target;
    
    AsteroidSpawner _as;

    #region Builder
    public AsteroidBuilder SetSpawner(AsteroidSpawner a)
    {
        _as = a;
        return this;
    }
    
    public AsteroidBuilder SetSprite(string path)
    {
        _spritePath = path;
        return this;
    }

    public AsteroidBuilder SetSizeBC(Vector2 vector)
    {
        _sizeBC = vector;
        return this;
    }

    public AsteroidBuilder SetSizeTrans(Vector2 vector)
    {
        _sizeTrans = vector;
        return this;
    }
    
    public AsteroidBuilder SetSpeed(float s)
    {
        _speed = s;
        return this;
    }

    public AsteroidBuilder SetBehaviour(IBehaviour behaviour)
    { 
        _ib = behaviour;
        return this;
    }
    #endregion

    public Asteroid Create(Asteroid a)
    {
        a.Create(_speed, _sizeBC, _sizeTrans, _ib, _as, _spritePath);
        return a;
    }
}
