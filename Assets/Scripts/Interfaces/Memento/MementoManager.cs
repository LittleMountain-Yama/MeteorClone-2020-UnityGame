using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoManager : MonoBehaviour
{

    public static MementoManager instance;

    private List<IReminder> _reminders = new List<IReminder>();

    private List<Coroutine> _recordCoroutines = new List<Coroutine>();
    private Coroutine _rememberCoroutine;

    private bool _isRemembering;    


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Memento_Rewind, OnRewindPowerUp);
    }

    public void Add(IReminder reminder)
    {
        _reminders.Add(reminder);

        var coroutine = StartCoroutine(reminder.StartToRecord());
        _recordCoroutines.Add(coroutine);
    }    

    private void OnRewindPowerUp(params object[] param)
    {
        StartCoroutine(RewindPowerUp());        
    }

    private void StartRecording()
    {
        foreach (var reminder in _reminders)
        {
            var coroutine = StartCoroutine(reminder.StartToRecord());
            _recordCoroutines.Add(coroutine);           
        }
    }

    private void StopRecording()
    {
        while (_recordCoroutines.Count > 0)
        {
            StopCoroutine(_recordCoroutines[0]);
            _recordCoroutines.RemoveAt(0);
        }
    }
    private IEnumerator RewindPowerUp()
    {
        _isRemembering = true;
        _rememberCoroutine = StartCoroutine(Remember());
        StopRecording();
        yield return new WaitForSeconds(5);
        StopCoroutine(_rememberCoroutine);            
            StartRecording();
        _isRemembering = false;        
    }

    private IEnumerator Remember()
    {        
        while (_isRemembering)
        {
            foreach (var reminder in _reminders)
            {
                reminder.Rewind();
            }
            yield return new WaitForSeconds(0.1f);
        }        
    }
}
