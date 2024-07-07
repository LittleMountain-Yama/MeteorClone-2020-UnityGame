using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    List<IActivable> _bombs = new List<IActivable>();

    static BombManager _instance;
    public static BombManager Instance
    {
        get { return _instance; }
        private set { }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void AddToList(Activable element)
    {
        //Debug.Log("Add to list activated");

        if (!_bombs.Contains(element))
        {
           //Debug.Log("Entrando a la lista");
           _bombs.Add(element);
        }
    }

    public void RemoveFromList(Activable element)
    {
        //Debug.Log("Saliendo de la lista");

        if (_bombs.Contains(element))
            _bombs.Remove(element);
    }

    public int GetCount()
    {
        return _bombs.Count;
    }

    public IActivable GetBomb(int id)
    {
        if (id <= 0 || id > _bombs.Count)
        {
            //Debug.Log("GetBomb: OutOfIndex " + id);
            return null;
        }
        else
        {
            //Debug.Log("GetBomb: Succesfull " + id);
            return _bombs[id - 1];            
        }
    }
}
