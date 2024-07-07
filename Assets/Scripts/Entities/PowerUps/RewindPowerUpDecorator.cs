using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindPowerUpDecorator : PowerUp
{
    public override void Execute()
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_Memento_Rewind);
        Destroy(gameObject);
    }
}
