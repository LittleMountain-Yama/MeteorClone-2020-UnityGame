using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : IMove
{
    Transform _t;
    float frequency = 4f, magnitude = 0.1f, forwardModifier = 8f;

    public void Move(float speed, GameObject target = null)
    {
        //Borrar: El sin solo va a hacer que el valor sube y baje en la misma posición, agregarle otra dimension para que se mueva.

        _t.transform.position += _t.transform.up * speed * forwardModifier * Time.deltaTime;
        //tendria que afectar solo el right (y)        

        _t.transform.position += _t.transform.right * speed * Mathf.Sin(Time.time * frequency) * magnitude;   
    }

    public void SetTransform(Transform t)
    {
        _t = t;  
    }
}
