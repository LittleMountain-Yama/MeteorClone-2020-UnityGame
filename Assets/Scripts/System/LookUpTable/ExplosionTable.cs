using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTable
{
    private int max = 3, min = 1;
    
    LookUpTable<int, Sprite> _selectExplosion;
    
    public ExplosionTable()
    {
        _selectExplosion = new LookUpTable<int, Sprite>(LoadSprite);
        
    }

    public Sprite SearchExplosion(int val)
    {
        return _selectExplosion.GetValue(val);
    }

    public Sprite LoadSprite(int val)
    {
        if (val < min || val > max)
            val = Random.Range(min, max);

        var newSprite = Resources.Load<Sprite>("Art/Explosion" + val);
        
        return newSprite;
    }
}
