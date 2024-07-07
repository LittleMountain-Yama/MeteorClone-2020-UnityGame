using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : ICommand
{
    Activable detonator = new Activable();

    public Detonate()
    {
        detonator.isDetonable = false;
        detonator.isVisited = true;
    }

    public void Do(float val = 0)
    {
        if (detonator != null)
        {
            detonator.UpdateID(1);

            //Debug.Log(BombManager.Instance.GetCount());
            detonator.Activate();
        }
    }
}
