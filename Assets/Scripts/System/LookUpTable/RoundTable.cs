using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTable
{
    LookUpTable<int, int> _asteroidPerRound;
    
    public RoundTable()
    {
        _asteroidPerRound = new LookUpTable<int, int>(CreateValue);
    }   

    public int SearchValue(int val)
    {
        return _asteroidPerRound.GetValue(val);
    }

    public int CreateValue(int val)
    {
        var newNum = (val * 3) + 2;
        return newNum;
    }
}
