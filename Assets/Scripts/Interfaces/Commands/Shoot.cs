using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : ICommand
{
    BulletSpawner _bs;

    public Shoot(BulletSpawner bs)
    {
        _bs = bs;
    }

    public void Do(float val = 0)
    {
        if (_bs != null)
            _bs.Shoot();
        else
            Debug.Log("Weapon not found");
    }
}
