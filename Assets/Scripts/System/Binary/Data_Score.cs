using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Data_Score : MonoBehaviour,IData
{
    public ScoreManager myManager;
    public string path;

    public void Load()
    {
        Info_Score AUX=BinarySerializer.LoadBinary<Info_Score>(Application.dataPath+ "/Resources/" + path + ".dat");
        EventManager.TriggerEvent(EventManager.EventsType.Event_Score_ChangeScore, AUX.score);


    }
    public void Save()
    {
        Info_Score AUX = new Info_Score();

        AUX.score = myManager.score;

        BinarySerializer.SaveBinary<Info_Score>(AUX,Application.dataPath + "/Resources/" + path + ".dat");
    }

}
[System.Serializable]
public class Info_Score
{
    public int score;
}