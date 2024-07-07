using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUpDecorator : PowerUp
{    
    public override void Execute()
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_Player_LifeModify,1);
        Destroy(gameObject);
    }
}
