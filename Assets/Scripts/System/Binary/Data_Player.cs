using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Data_Player : MonoBehaviour, IData
{
    public PlayerController myController;
    public string path;

    public void Load()
    {
        Info_Player AUX = BinarySerializer.LoadBinary<Info_Player>(Application.dataPath + "/Resources/" + path + ".dat");//LOAD 

        myController.transform.position = new Vector2(AUX.X_Position, AUX.Y_Position);
        myController.transform.up = new Vector2(AUX.X_Rotation, AUX.Y_Rotation);
        EventManager.TriggerEvent(EventManager.EventsType.Event_Player_LifeChange,AUX.life);
    }

    public void Save()
    {
        Info_Player AUX = new Info_Player();
        AUX.X_Position = myController.transform.position.x;
        AUX.Y_Position = myController.transform.position.y;
        AUX.X_Rotation = myController.transform.up.x;
        AUX.Y_Rotation = myController.transform.up.y;
        AUX.life = myController.currentLife;

        BinarySerializer.SaveBinary<Info_Player>(AUX, Application.dataPath + "/Resources/" + path + ".dat"); //SAVE
    }
}

[System.Serializable]
public class Info_Player
{
    public float X_Position;
    public float Y_Position;

    public int life;

    public float X_Rotation;
    public float Y_Rotation;

   
}