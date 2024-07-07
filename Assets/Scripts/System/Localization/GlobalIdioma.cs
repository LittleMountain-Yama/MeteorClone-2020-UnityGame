using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalIdioma : MonoBehaviour
{
    public static string idiomaActual = "Ingles";
    public Toggle toggleEspañol;
    public Toggle toggleIngles;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public string RotacionIdioma()
    {
        return (idiomaActual);
    }

    private void Start()
    {
        CambiarIdioma(idiomaActual);
    }

   
    public void CambiarIdioma(string idioma)
    {
        idiomaActual = idioma;
        NotificationCenter.DefaultCenter().PostNotification(this, "CambiarIdioma_");
    }


}
