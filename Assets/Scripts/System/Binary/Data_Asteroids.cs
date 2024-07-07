using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Asteroids : MonoBehaviour,IData
{
    public AsteroidSpawner myAsteroid_SP; 
    public string path;
    
    //Mediamente funcional, no podemos spawnear asteroides nuevos y ni cambiar sus tipos, pero las posiciones se actualizan
    public void Load()
    {
        AsteroidsList data = BinarySerializer.LoadBinary<AsteroidsList>(Application.dataPath + "/Resources/" + path + ".dat");
        
        var tempAst = FindObjectsOfType<Asteroid>();
        List<Asteroid> SaveList = new List<Asteroid>();

        Debug.Log("Data_Asteroid:Entré al Load");
        for (int i = 0; i < tempAst.Length; i++)
        {
            if (!SaveList.Contains(tempAst[i]))
            {
                SaveList.Add(tempAst[i]);
            }
        }
        
        if (SaveList.Count != data.ActiveAst) 
        {
            if (SaveList.Count > data.ActiveAst) //Cantidad en pantalla > Cantidad guardada
            {
                Debug.Log("Data_Asteroid:Entré al Mayor");
                for (int i = 0; i < SaveList.Count; i++)
                {
                    if (i < data.ActiveAst)
                    {
                        SaveList[i].transform.position = new Vector3(data.asteroidsList[i].X, data.asteroidsList[i].Y);
                    }
                    else
                    {
                        myAsteroid_SP.DestroyAsteroid(SaveList[i]);
                    }
                }
            }
            else if(SaveList.Count < data.ActiveAst) //Cantidad en pantalla < Cantidad guardada
            {
                Debug.Log("Data_Asteroid:Entré al Menor");
                /*if (SaveList.Count < data.ActiveAst)
                {
                    //EventManager.TriggerEvent(EventManager.EventsType.Event_Spawner_Spawn);
                }*/
                for (int i = 0; i < SaveList.Count; i++)
                {
                    if (i < data.ActiveAst)
                    {
                        SaveList[i].transform.position = new Vector3(data.asteroidsList[i].X, data.asteroidsList[i].Y);
                    }
                }
            }
            else
            {
                Debug.Log("Data_Asteroid:Entré al igual");
                for (int i = 0; i < SaveList.Count; i++)
                { 
                    SaveList[i].transform.position = new Vector3(data.asteroidsList[i].X, data.asteroidsList[i].Y);
                }
            }
        }

    }
    public void Save()
    {
        AsteroidsList data = new AsteroidsList();
        Info_Asteroids AUX = new Info_Asteroids();

        List<Asteroid> SaveList = new List<Asteroid>();

        data.ActiveAst = myAsteroid_SP.activeAsteroids;
        
        var tempAst = FindObjectsOfType<Asteroid>();
        
        for (int i = 0; i < tempAst.Length; i++)
        {
            if (!SaveList.Contains(tempAst[i]))
            {
               // AUX.Gen= tempAst[i]
                SaveList.Add(tempAst[i]);
            }
        }
        
        for (int i = 0; i < tempAst.Length; i++)
        {
            data.asteroidsList.Add(new Info_Asteroids());
            data.asteroidsList[i].X = SaveList[i].transform.position.x;
            data.asteroidsList[i].Y = SaveList[i].transform.position.y;
        }
        
        BinarySerializer.SaveBinary<AsteroidsList>(data, Application.dataPath + "/Resources/" + path + ".dat");
    }
}
[System.Serializable]
public class Info_Asteroids 
{
    public float X;
    public float Y;
}

[System.Serializable]
public class AsteroidsList
{
    public List<Info_Asteroids> asteroidsList = new List<Info_Asteroids>();
    public int rounds;
    public int ActiveAst;
}

