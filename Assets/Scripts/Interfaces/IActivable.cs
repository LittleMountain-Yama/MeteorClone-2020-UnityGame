using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MyA1-P3
public interface IActivable 
{
    IActivable next { get; set; }
    void Activate();
    void OnSpawn(Proyectile p = null);
}
