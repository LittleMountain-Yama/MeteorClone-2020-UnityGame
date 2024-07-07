using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IDecorator
{
    public abstract void Execute();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerModel p = collision.GetComponent<PlayerModel>();

        if (p)
        {
            Execute();
        }
    }
}
