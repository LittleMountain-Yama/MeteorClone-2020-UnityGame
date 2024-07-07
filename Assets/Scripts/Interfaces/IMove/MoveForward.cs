using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : IMove
{
    Transform _t;    
    
    public void Move(float speed, GameObject target = null)
    {
        _t.position += _t.transform.up * speed;    
    }

    public void SetTransform(Transform t)
    {
        _t = t;
    }
}
