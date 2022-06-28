using System;
using System.Collections;

namespace Base {
    public class SceneStorage {

        public bool IsInitialized = false;

        private InteractorsStorage interactorsStorage;
        private RepositoriesStorage repositoriesStorage;

        public SceneStorage(SceneConfig config) {
            interactorsStorage = new InteractorsStorage(config);
            repositoriesStorage = new RepositoriesStorage(config);
        }

        //@TODO public coroutine is bad
        public IEnumerator Initialize() {

            interactorsStorage.CreateAll();
            repositoriesStorage.CreateAll();

            yield return null;

            interactorsStorage.InvokeOnCreatedToAll();
            repositoriesStorage.SendOnCreatedToAll();

            yield return null;

            interactorsStorage.InitializeAll();
            repositoriesStorage.InitializeAll();
            IsInitialized = true;

            yield return null;

            interactorsStorage.InvokeOnStart();
            repositoriesStorage.InvokeOnStarted();
        }

        public T GetRepository<T>() where T : Repository, new() {
            return repositoriesStorage.Get<T>();
        }

        public T GetInteractor<T>() where T : Interactor, new() {
            return interactorsStorage.Get<T>();
        }
    }
}
