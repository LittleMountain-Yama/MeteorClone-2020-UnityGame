using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTable
{
    LookUpTable<int, PowerUp> _selectPowerUp;
    PowerUp newItem;
    
    public PowerUpTable()
    {
        _selectPowerUp = new LookUpTable<int, PowerUp>(LoadPowerUp);
    }

    public PowerUp SearchPowerUp(int val)
    {
        return _selectPowerUp.GetValue(val);
    }

    public PowerUp LoadPowerUp(int val)
    {
        if (val < 3 && val > 0)
        {
            newItem = Resources.Load<PowerUp>("PowerUps/PowerUp" + val);
        }
        else
        {
            newItem = null;
        }

        return newItem;
    }
}
