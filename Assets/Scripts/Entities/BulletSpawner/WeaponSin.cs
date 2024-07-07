using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponSin : Weapon
{
    public WeaponSin()
    {
        speed = 4f;
        lifeTime = 2.5f;
        cooldown = 0.3f;

        sprite = 2;
        moveID = 2;

        isInmortal = false;

        canColl = true;

        sizeBC = new Vector2(2, 1.6f);
        sizeTrans = new Vector2(2, 2);

        //moveType = new MoveSin();

        //activableType = null;
        actDelegate = GenerateActivable;
    }
    
    public override string AskForPath()
    {
        return FlyWeightProyectile.Sin.path;
    }

    public override IActivable GenerateActivable()
    {
        return null;
    }
}
