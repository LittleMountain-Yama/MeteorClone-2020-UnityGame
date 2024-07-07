using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : AsteroidType
{
    public AsteroidBig()
    {
        life = 1;

        speed = 7.8f;

        sizeBC = new Vector2(3, 3);
        sizeTrans = new Vector2(6, 6);

        iBehaviour = new BehaviourOneMedium();
    }

    public override string AskForPath()
    {
        return FlyWeightAsteroid.Big.path;
    }
}
