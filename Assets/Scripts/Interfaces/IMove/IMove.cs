using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void Move(float speed, GameObject target = null);
    void SetTransform(Transform t);
}
