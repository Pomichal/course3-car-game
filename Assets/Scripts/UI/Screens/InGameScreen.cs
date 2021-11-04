using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class InGameScreen : ScreenBase
    {

        public TextMeshProUGUI elapsedTimeText;

        public void ReturnToMenu()
        {
            App.gameManager.ReturnToMenu();
            Hide();
        }

        public override void Show()
        {
            base.Show();
            StartCoroutine(UpdateTimer());
        }

        IEnumerator UpdateTimer()
        {
            while(gameObject.activeSelf)
            {
                elapsedTimeText.text = App.levelManager.elapsedTime.ToString("g");
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
