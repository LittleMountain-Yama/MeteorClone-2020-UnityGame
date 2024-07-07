using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourOneMedium : IBehaviour
{
    public void OnHit(Vector3 v)
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_Spawn, 1, v);
    }
}
