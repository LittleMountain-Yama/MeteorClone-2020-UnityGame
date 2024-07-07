using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : IShoot
{
    private BulletSpawner _bs;
    
    public Constant(BulletSpawner bs)
    {
        _bs = bs;
    }
    
    public void Shoot(Proyectile p)
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _bs.DestroyProyectile(p);
        }
    }
}
