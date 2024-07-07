using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMedium : AsteroidType
{
    public AsteroidMedium()
    {
        speed = 10f;

        life = 1;

        sizeBC = new Vector2(1.8f, 1.8f);
        sizeTrans = new Vector2(5, 5);

        iBehaviour = new BehaviourTwoSmall();
    }
    
    public override string AskForPath()
    {
        return FlyWeightAsteroid.Medium.path;
    }
}
