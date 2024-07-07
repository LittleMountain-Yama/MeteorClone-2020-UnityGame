using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AsteroidType
{
   public float speed;
   public int life;
   public Vector2 sizeBC, sizeTrans;
   public IBehaviour iBehaviour;

   public abstract string AskForPath();
}
