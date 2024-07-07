using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightAsteroid : MonoBehaviour
{
    public static readonly FlyWeight Default = new FlyWeight
    {
        sound = 4,
        explosionTable = new ExplosionTable(),
        powerUpTable =  new PowerUpTable(),
    };
    
    public static readonly FlyWeight Big = new FlyWeight
    {
       path = "Art/Asteroid_Big",
    };

    public static readonly FlyWeight Medium = new FlyWeight
    {
        path = "Art/Asteroid_Medium",
    };

    public static readonly FlyWeight Small = new FlyWeight
    {
       path = "Art/Asteroid_Small",
    };
}
