using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        public ParamEvent<int> onCheckpointReached = new ParamEvent<int>();
        public UnityEvent onFinalReached = new UnityEvent();
        public UnityEvent onStart = new UnityEvent();

        public TimeSpan elapsedTime { get => DateTime.Now - startTime; }

        private DateTime startTime;

        // Start is called before the first frame update
        void Awake()
        {
            App.levelManager = this;
            StartGame();
        }

        public void FinishGame()
        {
            onFinalReached.Invoke();
            App.screenManager?.Show<WinScreen>(
                    new Dictionary<string, object>
                    {
                        {"time", elapsedTime }
                    });
        }

        public void StartGame()
        {
            startTime = DateTime.Now;
            onStart.Invoke();
        }
    }
}
