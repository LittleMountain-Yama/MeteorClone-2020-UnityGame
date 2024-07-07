using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    List<IUpdate> _subscribers = new List<IUpdate>();

    static UpdateManager _instance;

    public GameObject pauseUI;
    public static UpdateManager Instance
    {
        get { return _instance; }
        private set { }
    }

    bool pause;

    private void Awake()
    {
        _instance = this;
        _subscribers = new List<IUpdate>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pause = !pause;

        if (pause)
            pauseUI.SetActive(true);
        else
            pauseUI.SetActive(false);

        if (pause)
            return;

        AllUpdates();        
    }

    void AllUpdates()
    {        
        for (int i = 0; i < _subscribers.Count; i++)
        {
            _subscribers[i].OnUpdate();           
        }                    
    }

    public void AddToUpdate(IUpdate element)
    {
        if (!_subscribers.Contains(element))
            _subscribers.Add(element);
    }

    public void RemoveFromUpdate(IUpdate element)
    {
        if (_subscribers.Contains(element))
            _subscribers.Remove(element);
    }
}
