using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{

    public int index;
    public bool isFinal;
    public bool isFirst;

    public bool active;

    public virtual void Start()
    {
        App.levelManager.onStart.AddListener(SetupCheckpoint);
        SetupCheckpoint();
    }

    public void SetupCheckpoint()
    {
        active = isFirst;
        App.levelManager.onCheckpointReached.AddListener(ActivateIfNext);
    }

    public void ActivateIfNext(int idToActivate)
    {
        if(index == idToActivate)
        {
            App.levelManager.onCheckpointReached.RemoveListener(ActivateIfNext);
            active = true;
        }
    }

    public void SetChecked()
    {
        if(active)
        {
            App.levelManager.onCheckpointReached.Invoke(index + 1);
            active = false;
            if(isFinal)
            {
                App.levelManager.FinishGame();
            }
        }
    }
}
