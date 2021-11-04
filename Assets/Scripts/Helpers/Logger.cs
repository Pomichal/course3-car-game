using UnityEngine;
/// <summary>
/// You can use this custom logger even outside MonoBehaviour
/// </summary>

public static class Logger
{
    public static void Log(string message, MessageTypes type = MessageTypes.Log, int verboseLevel = 3)
    {
        if (verboseLevel <= App.staticVerboseLevel)
        {
            switch (type)
            {
                case MessageTypes.Log:
                    Debug.Log(message);
                    break;
                case MessageTypes.Warning:
                    Debug.LogWarning(message);
                    break;
                case MessageTypes.Error:
                    Debug.LogError(message);
                    break;
            }
        }
    }
}

