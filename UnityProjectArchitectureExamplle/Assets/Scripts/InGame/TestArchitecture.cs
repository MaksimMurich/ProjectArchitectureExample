using Assets.Scripts;
using Base;
using System.Collections;
using UnityEngine;
using User;

public class TestArchitecture : MonoBehaviour {

    public static SceneManagerBase sceneManager;

    [SerializeField] private TMPro.TMP_Text openAppCount;

    private void Start() {
        sceneManager = new ScenesManagerExample();
        sceneManager.InitializeSceneConfigs();
        sceneManager.LoadCurrentSceneAsync();
        Coroutines._StartCoroutine(StartGameRoutine());
    }

    public IEnumerator StartGameRoutine() {

        while (sceneManager.currentScene == null || !sceneManager.currentScene.IsInitialized) {
            yield return null;
        }

        UserFeature userInteractor = sceneManager.currentScene.GetInteractor<UserFeature>();
        userInteractor.AddOpenAppCount();
        openAppCount.text = userInteractor.OpenAppCount.ToString();
    }
}
