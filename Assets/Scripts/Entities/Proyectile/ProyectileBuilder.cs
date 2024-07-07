using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileBuilder 
{ 
    float _speed, _lifeTime;
    int _damage, _sound, _moveID;
    private string _spritePath;
    bool _isInmortal, _canColl;

    private Vector2 _sizeTrans, _sizeBC;
    private BoxCollider2D _bc;
    SpriteRenderer _sr;
    BulletSpawner _bs;

    IActivable _act;
    
    #region Builder
    public ProyectileBuilder SetSpawner(BulletSpawner bs)
    {
        _bs = bs;
        return this;
    }

    //Values
    public ProyectileBuilder SetSpeed(float spd)
    {
        _speed = spd;
        return this;
    }    

    public ProyectileBuilder SetLifeTime(float f)
    {
        _lifeTime = f;
        return this;
    }
    
    public ProyectileBuilder SetMoveType(int v)
    {
        _moveID = v;
        return this;
    }

    public ProyectileBuilder SetInmortality(bool b)
    {
        _isInmortal = b;
        return this;
    }

    public ProyectileBuilder SetCollision(bool b)
    {
        _canColl = b;
        return this;
    }

    //Sizing
    public ProyectileBuilder SetSizeBC(Vector2 vector)
    {
        _sizeBC = vector;
        return this;
    }

    public ProyectileBuilder SetSizeTrans(Vector2 vector)
    {
        _sizeTrans = vector;
        return this;
    }

    //Feedback
    public ProyectileBuilder SetSprite(string path)
    {
        _spritePath = path;
        return this;
    }
    
    public ProyectileBuilder SetSound(int s)
    {
        _sound = s;
        return this;
    }

    public ProyectileBuilder SetActivable(IActivable a)
    {
        _act = a;
        return this;
    }
    #endregion

    public Proyectile Create(Proyectile p)
    {
       p.Create(_speed, _lifeTime, _sound, _moveID, _isInmortal, _canColl,_sizeBC, _sizeTrans, _act, _bs, _spritePath);
       return p;
    }
}
