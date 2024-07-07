using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStatic : IMove
{
    private GameObject _go;
    public MoveStatic(GameObject go)
    {
        _go = go;
    }
    
    public void Move(float speed, GameObject target = null)
    {
       
    }

    public void SetTransform(Transform t)
    {
        t.parent = _go.transform;
    }
}
