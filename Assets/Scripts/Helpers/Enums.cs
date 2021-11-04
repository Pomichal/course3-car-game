using UnityEngine.Events;

public enum MessageTypes
{
    Log, Warning, Error
}


public class ParamEvent<T> : UnityEvent<T> { }

