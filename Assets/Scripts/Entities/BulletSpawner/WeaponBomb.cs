using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBomb : Weapon
{
    public WeaponBomb()
    {
        speed = 1f;
        lifeTime = 3f;
        cooldown = 0.57f;

        sprite = 3;
        moveID = 1;

        isInmortal = true;

        canColl = false;

        sizeBC = new Vector2(3, 3);
        sizeTrans = new Vector2(2, 2);

        //activableType = new Activable();
        actDelegate = GenerateActivable;
    }

    public override string AskForPath()
    {
        return FlyWeightProyectile.Bomb.path;
    }

    public override IActivable GenerateActivable()
    {
        var temp = new Activable();
        return temp;        
    }
}
