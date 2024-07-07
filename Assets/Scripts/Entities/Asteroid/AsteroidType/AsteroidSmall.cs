using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmall : AsteroidType
{
    public AsteroidSmall()
    {
        speed = 12.5f;

        life = 1;

        sizeBC = new Vector2(1.5f, 1.5f);
        sizeTrans = new Vector2(4, 4);

        iBehaviour = new BehaviourEmpty();
    }
    
    public override string AskForPath()
    {
        return FlyWeightAsteroid.Small.path;
    }
}
