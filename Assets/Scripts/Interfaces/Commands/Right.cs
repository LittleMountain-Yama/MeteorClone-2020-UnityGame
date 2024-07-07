using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : ICommand
{
    Transform _t;

    public Right(Transform t)
    {
        _t = t;
    }

    public void Do(float speed)
    {
        //float velY = _rb.velocity.y;
        _t.position += new Vector3(1 * speed, 0, 0);
    }
}
