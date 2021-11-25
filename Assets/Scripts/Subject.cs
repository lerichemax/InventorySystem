using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<Observer> _observers = new List<Observer>();

    public void AddObserver(Observer obs)
    {
        _observers.Add(obs);
    }

    public void RemoveObserver(Observer obs)
    {
        _observers.Remove(obs);
    }

    protected void Notify(object obj, ObserverEvent obsEvent)
    {
        foreach (Observer obs in _observers)
        {
            obs.OnNotify(obj, obsEvent);
        }
    }
}
