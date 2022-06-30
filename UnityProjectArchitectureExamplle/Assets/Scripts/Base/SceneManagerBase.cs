using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base {
    public abstract class SceneManagerBase {

        public event Action<SceneStorage> OnSceneLoadedEvent;

        public bool IsLoading { get; private set; }
        public SceneStorage currentScene { get; private set; }

        public Dictionary<string, SceneConfig> SceneConfigs;

        public SceneManagerBase() {
            SceneConfigs = new Dictionary<string, SceneConfig>();
        }

        public abstract void InitializeSceneConfigs();

        public Coroutine LoadCurrentSceneAsync() {
            if (IsLoading) {
                throw new Exception("Try load new scene while loading other scene");
            }

            string sceneName = SceneManager.GetActiveScene().name;
            SceneConfig config = SceneConfigs[sceneName];
            return Coroutines._StartCoroutine(this.LoadCurrentSceneRoutine(config));

        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig config) {
            IsLoading = true;
            yield return Coroutines._StartCoroutine(InitializeSceneRoutine(config));
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(currentScene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName) {
            if (IsLoading) {
                throw new Exception("Try load new scene while loading other scene");
            }

            var config = SceneConfigs[sceneName];
            return Coroutines._StartCoroutine(this.LoadNewSceneRoutine(config));

        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig config) {
            IsLoading = true;
            yield return Coroutines._StartCoroutine(InitializeSceneRoutine(config));
            yield return Coroutines._StartCoroutine(LoadSceneRoutine(config));
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(currentScene);
        }

        public IEnumerator InitializeSceneRoutine(SceneConfig config) {
            currentScene = new SceneStorage(config);
            yield return currentScene.Initialize();
        }

        private IEnumerator LoadSceneRoutine(SceneConfig config) {

            var async = SceneManager.LoadSceneAsync(config.SceneName);
            async.allowSceneActivation = false;

            while(async.isDone) {
                yield return null;
            }

            async.allowSceneActivation = true;
        }

        public T GetInteractor<T>() where T : Feature, new() {
            return currentScene.GetInteractor<T>();
        }
    }
}
