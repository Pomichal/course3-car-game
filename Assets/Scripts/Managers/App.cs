using Managers;
using UnityEngine;
using UnityEngine.Events;

public class App : MonoBehaviour
{
    public static UnityEvent onLoadingProgressed = new UnityEvent();

    public static ScreenManager screenManager;
    public static GameManager gameManager;
    public static LevelManager levelManager;
    public static DataManager dataManager;
    public static SceneLoader sceneLoader;

    public static int staticVerboseLevel;
    public int verboseLevel;    // 0 - no logs ... 3 - log everything

    private void Awake()
    {
        dataManager = new DataManager();
        staticVerboseLevel = verboseLevel;
    }
}
