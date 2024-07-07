using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BinaryData_Manager : MonoBehaviour
{
    IData[] AllData;

    private void Awake()
    {
        AllData = GetComponentsInChildren<IData>();
    }

    public void Load()
    {
        for(int i = 0; i < AllData.Length; i++)
        {
            AllData[i].Load();
            Debug.Log(i);
        }
    }

    public void Save()
    {
        
        for (int i = 0; i < AllData.Length; i++)
        {
            AllData[i].Save();
            Debug.Log("hola");
        }
    }

}
