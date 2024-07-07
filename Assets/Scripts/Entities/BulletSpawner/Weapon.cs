using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public float speed, lifeTime, cooldown;
    public int sound, sprite, moveID;
    public bool isInmortal;

    public bool canColl;

    public Vector2 sizeTrans, sizeBC;
    
    //public IMove moveType;
    public IShoot shootType;

    public abstract string AskForPath();

    //ActivableInterface

    //public IActivable activableType;
    public delegate IActivable ActivableDelegate();
    public ActivableDelegate actDelegate;

    public abstract IActivable GenerateActivable();   
}
