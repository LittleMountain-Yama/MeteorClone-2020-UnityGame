using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon
{
    public WeaponLaser()
    {
        speed = 0f;
        lifeTime = 0.1f;
        cooldown = 0.5f;

        sprite = 1;
        moveID = 1;

        isInmortal = true;

        canColl = true;

        sizeBC = new Vector2(1, 1);
        sizeTrans = new Vector2(2, 10);

        //moveType = new MoveStatic(null);
        //activableType = null;

        actDelegate = GenerateActivable;
    }
    public override string AskForPath()
    {
        return FlyWeightProyectile.Laser.path;
    }

    public override IActivable GenerateActivable()
    {
        return null;
    }
}
