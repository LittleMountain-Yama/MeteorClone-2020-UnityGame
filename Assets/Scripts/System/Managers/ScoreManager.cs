using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IReminder
{
    private int _score;
    public int score { get { return _score; } }

    public Text myScore;

    private Memento<ScoreSnapshot> _memento = new Memento<ScoreSnapshot>();// MEMENTO

    void Start()
    {
        myScore.text = "" + _score;
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Score_AddScore, OnProyectileHit);
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Score_ChangeScore, OverrideScore);
        MementoManager.instance.Add(this); // MEMENTO
    }

    void OnProyectileHit(params object[] param)
    {
        var points = (int)param[0];
        _score += points;
        myScore.text = "" + _score;
    }

    void OverrideScore(params object[] param)
    {
        var points = (int)param[0];
        _score = points;
        myScore.text = "" + _score;
    }

    #region  MementoFunction
    public void MakeSnapshot()
    {
        var snapshot = new ScoreSnapshot();
        snapshot.score = _score;


        _memento.Record(snapshot);
    }

    public void Rewind()
    {
        if (!_memento.CanRemember()) return;

        var snapshot = _memento.Remember();

        _score = snapshot.score;
        myScore.text = "" + _score;
    }

    public IEnumerator StartToRecord()
    {
        while (true)
        {
            MakeSnapshot();

            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion

}
