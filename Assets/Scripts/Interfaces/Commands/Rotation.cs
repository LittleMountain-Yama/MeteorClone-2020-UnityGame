using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : ICommand
{
    Transform _t;
    
    public Rotation(Transform t)
    {
        _t = t;
    }
    
    public void Do(float val)
    {
        Vector3 lookAtPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAtPos.z = _t.position.z;
        _t.up = lookAtPos - _t.position;

    }
}
