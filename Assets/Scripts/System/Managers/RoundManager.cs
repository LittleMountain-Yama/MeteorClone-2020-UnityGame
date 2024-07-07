using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    private int loadingRounds = 5, currentRound; //rondas a cargas y en cual estamos
    
    private RoundTable _rt;

    private void Start()
    {
        currentRound = 1;
        
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Round_Change, RoundCount);
        
        _rt = new RoundTable();

        for (int i = 1; i < loadingRounds + 1; i++)
        {
            _rt.CreateValue(i);
        }
        
        StartCoroutine(NewRound());
    }
    
    public IEnumerator NewRound()
    {
        if (currentRound < loadingRounds)
        {
            yield return new WaitForSeconds(1);            
            EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_AsteroidsQuantity, 
                CalculateRound(currentRound));
        }
        else
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_Game_Win);
        }
    }
    
    int CalculateRound(int round)
    {
        return _rt.SearchValue(round);
    }

    #region  Events
    void RoundCount(params object[] param)
    {
        currentRound++;
        StartCoroutine(NewRound());
    }
    #endregion
}
