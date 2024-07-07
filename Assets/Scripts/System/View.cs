using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public Text myLife;
    public Sprite[] weaponImages;
    public Image choosenWeapon;

    void Start()
    {
        //myLife.text = "LIVES: " + life;
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_HUD_Life, OnLifeUpdate);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_HUD_Weapon, OnWeaponChange);
    }

    void OnLifeUpdate(params object[] param)
    {
        var playerLife = (int)param[0];
        // life = playerLife;
        // myLife.text = "LIVES: " + life;
    }

    void OnWeaponChange(params object[] param)
    {        
        var index = (int)param[0];
        if (weaponImages != null)
        {
            choosenWeapon.sprite = weaponImages[index];
        }
    }
}
