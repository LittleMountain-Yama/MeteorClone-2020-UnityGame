using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethod<T> : MonoBehaviour
{
    private GameObject _prefab;

    public FactoryMethod(GameObject prefab)
    {
        _prefab = prefab;
    }
    
    public GameObject Factory()
    {
        return Instantiate(_prefab);
    }

}
