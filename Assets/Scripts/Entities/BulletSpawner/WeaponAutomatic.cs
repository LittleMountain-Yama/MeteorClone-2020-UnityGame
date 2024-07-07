using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutomatic : Weapon
{
   public WeaponAutomatic()
   {
      speed = 1f;
      lifeTime = 3f;
      cooldown = 0.57f;

      sprite = 0;
      moveID = 0;

      isInmortal = false;

      canColl = true;

      sizeBC = new Vector2(1, 1);
      sizeTrans = new Vector2(1, 1);

       //moveType = new MoveForward();
       //activableType = null;

       actDelegate = GenerateActivable;
   }

   public override string AskForPath()
   {
      return FlyWeightProyectile.Automatic.path;
   }

   public override IActivable GenerateActivable()
   {
        return null;
   }
}
