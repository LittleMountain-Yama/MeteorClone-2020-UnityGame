using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightProyectile : MonoBehaviour
{
    public static readonly FlyWeight Default = new FlyWeight
    {
        deathAnim = Resources.Load<Sprite>("Art/Explosion2"),
    };
        
    public static readonly FlyWeight Automatic = new FlyWeight
    {
        path = "Art/Shoot_Automatic"
    };

    public static readonly FlyWeight Laser = new FlyWeight
    {
        path = "Art/Shoot_Laser"
    };

    public static readonly FlyWeight Sin = new FlyWeight
    {
        path = "Art/Shoot_SIN"
    };

    public static readonly FlyWeight Bomb = new FlyWeight
    {        
        path = "Art/Bomb"
    };
}
