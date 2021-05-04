using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Observer Abstract class awaiting notification
public abstract class Observer : MonoBehaviour
{
   public abstract void OnNotify(object value, NotificationType notificationType);
}

//Subject sends the notification of specific type
public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observers = new List<Observer>();
    //Puts all observers for this subject in list.
    public void RegisterObserver(Observer observer)
    {
        _observers.Add(observer);
    }

    //Notifys observer of specific notification
    public void Notify(object value, NotificationType notificationType)
    {
        foreach (var observer in _observers)
            observer.OnNotify(value, notificationType);
    }
}
