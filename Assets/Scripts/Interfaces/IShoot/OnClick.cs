using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : IShoot
{
     private BulletSpawner _bs;
     
     public OnClick(BulletSpawner bs)
     {
          _bs = bs;
     }
     
     public void Shoot(Proyectile p)
     {
         
     }
}
