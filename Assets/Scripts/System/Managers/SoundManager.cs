using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sounds;

    private AudioSource _as;

    private void Start()
    {
    }

    private void Awake()
    {
        _as = FindObjectOfType<AudioSource>();
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Sound_Trigger, OnTriggerSound);        
    }

    void OnTriggerSound(params object[] param)
    {
        _as.clip = sounds[(int)param[0]];
        _as.Play();
    }
}
