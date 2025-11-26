using UnityEngine;

public interface IObserver
{
    public void OnNotify(string eventName);
}
