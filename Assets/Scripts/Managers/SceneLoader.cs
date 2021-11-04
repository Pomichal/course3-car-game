using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {

        private LoadingPopup loadingPopup;

        void Awake()
        {
            App.sceneLoader = this;
            loadingPopup = GetComponentInChildren<LoadingPopup>(true);
            if (loadingPopup == null)
            {
                throw new System.NullReferenceException("loadingPopup is null, please add a LoadingPopup as a child of SceneLoader");
            }
        }

        public void LoadingPopupOn(int concurentEventsNumber,
                ICommand afterLoadingPopupHideCommand = null)
        {
            loadingPopup.Show(new Dictionary<string, object>()
                    {
                        {"endEvent", App.onLoadingProgressed},
                        {"numberOfEvents", concurentEventsNumber},
                        {"afterHideCommand", afterLoadingPopupHideCommand}
                    });
        }

        public void LoadScene(string loadSceneName,
                int concurentEventsNumber = 1,    // set to 0 for silent loading (without popup)
                ICommand afterLoadingPopupHideCommand = null,
                ICommand afterSceneLoadingFinishedCommand = null,
                bool setAsActive = false)
        {
            if (concurentEventsNumber != 0)
            {
                LoadingPopupOn(concurentEventsNumber, afterLoadingPopupHideCommand);
            }
            StartCoroutine(SceneLoaderCoroutine(loadSceneName, afterSceneLoadingFinishedCommand, setAsActive));
        }

        public void UnLoadScene(string unloadSceneName,
                int concurentEventsNumber = 1,    // set to 0 for silent loading (without popup)
                ICommand afterLoadingPopupHideCommand = null,
                ICommand afterSceneUnloadingFinishedCommand = null
                )
        {
            if (concurentEventsNumber != 0)
            {
                LoadingPopupOn(concurentEventsNumber, afterLoadingPopupHideCommand);
            }
            StartCoroutine(SceneUnLoaderCoroutine(unloadSceneName, afterSceneUnloadingFinishedCommand));
        }

        public void ChangeScenes(string loadSceneName,
                string unloadSceneName,
                int concurentEventsNumber = 2,    // set to 0 for silent loading (without popup)
                ICommand afterLoadingPopupHideCommand = null,
                ICommand afterSceneLoadingFinishedCommand = null,
                ICommand afterSceneUnloadingFinishedCommand = null
                )
        {
            if (concurentEventsNumber != 0)
            {
                LoadingPopupOn(concurentEventsNumber, afterLoadingPopupHideCommand);
            }
            StartCoroutine(SceneLoaderCoroutine(loadSceneName, afterSceneLoadingFinishedCommand));
            StartCoroutine(SceneUnLoaderCoroutine(unloadSceneName, afterSceneUnloadingFinishedCommand));
        }

        private IEnumerator SceneLoaderCoroutine(string sceneName, ICommand afterFinishedCommand = null, bool setAsActive = false)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            asyncLoad.allowSceneActivation = false;
            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
                {
                    asyncLoad.allowSceneActivation = true;
                }
                yield return new WaitForSeconds(1);     // For presentation purposes. Remove in production!!!
            }
            if (afterFinishedCommand != null)
            {
                afterFinishedCommand.Execute();
            }
            if (setAsActive)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            }
            App.onLoadingProgressed.Invoke();
            Logger.Log(sceneName + " scene loaded", MessageTypes.Log, 2);
        }

        private IEnumerator SceneUnLoaderCoroutine(string sceneName, ICommand afterFinishedCommand = null)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
            while (!asyncUnload.isDone)
            {
                yield return new WaitForSeconds(1);     // For presentation purposes. Remove in production!!!
            }
            if (afterFinishedCommand != null)
            {
                afterFinishedCommand.Execute();
            }
            App.onLoadingProgressed.Invoke();
            Logger.Log(sceneName + " scene unloaded", MessageTypes.Log, 2);
        }
    }
}
