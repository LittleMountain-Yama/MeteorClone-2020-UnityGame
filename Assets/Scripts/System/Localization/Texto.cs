using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    public string español;
    public string ingles;

    public bool esButton;

    public Toggle toggleEspañol;
    public Toggle toggleIngles;

    public GlobalIdioma globalIdioma;


    private void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "CambiarIdioma_");
        CambiarIdioma_();

    }

    private void Awake()
    {
        globalIdioma = GameObject.Find("AuxIdioma").GetComponent<GlobalIdioma>();
    }


    public void CambiarIdioma_()
   {
        if (globalIdioma.RotacionIdioma()=="Español")
        {      
                GetComponent<Text>().text = español; ////  
        }
        if (globalIdioma.RotacionIdioma() == "Ingles")
        {
                GetComponent<Text>().text = ingles; ////
        }
        else
        {
            return;
        }


    }


}
