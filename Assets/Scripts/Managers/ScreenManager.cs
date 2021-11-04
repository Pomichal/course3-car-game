using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Managers
{
    public class ScreenManager : MonoBehaviour
    {

        private ScreenBase[] _screens;

        void Awake()
        {
            _screens = GetComponentsInChildren<ScreenBase>(true);
            App.screenManager = this;
        }

        public void Show<T>()
        {
            foreach (var screen in _screens)
            {
                if (screen.GetType() == typeof(T))
                {
                    screen.Show();
                }
            }
        }

        public void Show<T>(Dictionary<string, object> parameter = null)
        {
            foreach (var screen in _screens)
            {
                if (screen.GetType() == typeof(T))
                {
                    screen.Show(parameter);
                }
            }
        }

        public void Hide<T>()
        {
            foreach (var screen in _screens)
            {
                if (screen.GetType() == typeof(T))
                {
                    screen.Hide();
                }
            }
        }
    }
}
