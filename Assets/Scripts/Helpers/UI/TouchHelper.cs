using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// This script is used to check, if your current click/tap is over UI or not.
/// This is used in games, where you have a clickable/touchable UI during the gameplay with mouse clicking.
/// It will prevent activating the in-game script when clicking on a button in the UI.
/// </summary>
public static class TouchHelper
{
    public static bool IsPointerOverGameObject()
    {
        //check mouse
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
            {
                return true;
            }
        }
        return false;
    }
}
