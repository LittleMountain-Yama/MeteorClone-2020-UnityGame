using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{
    public delegate T2 FactoryMethod(T1 keyToReturn);

    Dictionary<T1, T2> _values;

    FactoryMethod _factoryMethod;

    public LookUpTable(FactoryMethod f)
    {
        _factoryMethod = f;
        _values = new Dictionary<T1, T2>();
    }

    public T2 GetValue(T1 v)
    {
        if (!_values.ContainsKey(v))
            _values[v] = _factoryMethod(v);
        
        return _values[v];
    }
}
