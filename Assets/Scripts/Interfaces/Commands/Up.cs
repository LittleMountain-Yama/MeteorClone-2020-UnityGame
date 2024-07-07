using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : ICommand
{
    Transform _t;

    public Up(Transform t)
    {
        _t = t;
    }

    public void Do(float speed)
    {
        //float velY = _rb.velocity.y;
        _t.position += new Vector3(0,1 * speed, 0);
    }
}
