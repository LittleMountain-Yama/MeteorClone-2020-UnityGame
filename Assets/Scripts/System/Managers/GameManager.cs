using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Game_Win, OnPlayerWin);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Game_Lose, OnPlayerLose);
    }

    void OnPlayerWin(params object[] param)
    {
        SceneManager.LoadScene("Win");
    }

    void OnPlayerLose(params object[] param)
    {
        SceneManager.LoadScene("Lose");
    }
}
