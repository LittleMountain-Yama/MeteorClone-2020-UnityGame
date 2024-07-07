using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : ICommand
{
    BulletSpawner _bs;

    public ChangeWeapon(BulletSpawner bs)
    {
        _bs = bs;
    }

    public void Do(float val = 0)
    {     
        if (_bs != null)
            _bs.ChangeWeapon();
        else
            Debug.Log("Weapon not found");
    }
}
