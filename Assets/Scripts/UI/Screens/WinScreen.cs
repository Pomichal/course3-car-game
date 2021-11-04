using System;
using System.Collections.Generic;
using TMPro;

namespace UI
{
    public class WinScreen : ScreenBase
    {

        public TextMeshProUGUI timeText;

        public override void Show(Dictionary<string, object> parameter=null)
        {
            base.Show(parameter);
            timeText.text = ((TimeSpan)parameter["time"]).ToString("g");
        }

        public void RestartGame()
        {
            App.levelManager.StartGame();
            Hide();
        }

        public void ReturnToMenu()
        {
            App.gameManager.ReturnToMenu();
            Hide();
        }
    }
}
