using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<IObserver> _observers = new List<IObserver>();

    protected void NotifyObservers(ScoreEnum scoreData)
    {
        if(_observers.Count != 0)
        {
            _observers.ForEach(observer =>
            {
                observer.OnNotify(scoreData);
            });
        }
    }

    public void AddObserver(IObserver observer)
    {
        if (observer != null)
        {
            _observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if(observer != null)
        {
            _observers.Remove(observer);
        }
    }

}
