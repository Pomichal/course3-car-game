using Commands;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        void Start()
        {
            App.gameManager = this;
            App.sceneLoader.LoadScene("UIScene", 1, new ShowScreenCommand<MenuScreen>());
        }

        public void StartGame()
        {
            App.sceneLoader.LoadScene("InGameScene", 1, new ShowScreenCommand<InGameScreen>());
        }

        public void ReturnToMenu()
        {
            App.sceneLoader.UnLoadScene("InGameScene", 1, new ShowScreenCommand<MenuScreen>());
        }
    }
}
