using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
    public class LoadingPopup : ScreenBase
    {
        public TextMeshProUGUI progressText;    // TODO: replace with game tip etc
        public Slider slider;
        private ICommand afterHideCommand;
        private int numberOfEvents;
        private int maxNumberOfEvents;
        private UnityEvent hideEvent;
        private float progress;
        private float speed = 50;

        public override void Show(Dictionary<string, object> parameter=null)
        {
            base.Show(parameter);
            hideEvent = ((UnityEvent)parameter["endEvent"]);
            hideEvent.AddListener(EventOccured);
            maxNumberOfEvents = ((int)parameter["numberOfEvents"]);
            numberOfEvents = maxNumberOfEvents;
            if(parameter["afterHideCommand"] != null)
            {
                afterHideCommand = (ICommand)parameter["afterHideCommand"];
            }
            progress = 0;
        }

        public void Update()
        {
            if(gameObject.activeSelf)
            {
                if(progress <
                    (maxNumberOfEvents - numberOfEvents + 1) * 100/maxNumberOfEvents &&
                    progress < 100)
                {
                    progress += Time.deltaTime * speed;
                }
                if(progress > 100)
                {
                    progress = 100;
                }
                progressText.text = (int)progress + "%";
                slider.value = progress / 100;
            }
        }

        public override void Hide()
        {
            Logger.Log("Hide loading popup", MessageTypes.Log, 2);
            hideEvent.RemoveListener(EventOccured);
            if(afterHideCommand != null)
            {
                afterHideCommand.Execute();
            }
            gameObject.SetActive(false);
        }

        void EventOccured()
        {
            numberOfEvents -= 1;
            progress = (maxNumberOfEvents - numberOfEvents) * 100 / maxNumberOfEvents;
            if(numberOfEvents <= 0)
            {
                Hide();
            }
        }
    }
}
