using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private int _lives = 3, maxLife = 3;
    public int lives { get { return _lives; } }

    public Text myLives;

    private Memento<ScoreSnapshot> _memento = new Memento<ScoreSnapshot>();// MEMENTO

    void Start()
    {
        myLives.text = "" + _lives;
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Player_LifeModify, UpdateHUD);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Player_LifeChange, ForceHUD);
    }

    void UpdateHUD(params object[] param)
    {
        var newLife = (int)param[0];
        if (newLife > maxLife)
        {
            newLife = maxLife;
        }
        myLives.text = "" + _lives;
    }
    
    void ForceHUD(params object[] param)
    {
        var newLife = (int)param[0];
        if (newLife > maxLife)
        {
            newLife = maxLife;
        }
        myLives.text = "" + _lives;
    }
    
}
