using System;
using System.Collections.Generic;
using User;

namespace Base {

    public class InteractorsStorage {

        private Dictionary<Type, Interactor> interactors;

        private SceneConfig sceneConfig;

        public InteractorsStorage(SceneConfig sceneConfig) {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAll() {
            interactors = sceneConfig.CreateAllInteractors();
        }

        /// <summary>
        /// Calls OnCreated for each of the interactors
        /// </summary>
        public void InvokeOnCreatedToAll() {
            foreach (var item in interactors) {
                item.Value.OnCreated();
            }
        }

        public void InitializeAll() {
            Initialize<UserInteractor>();
        }

        public void Initialize<T>() where T : Interactor, new() {
            interactors[typeof(T)].Initialize();
        }

        /// <summary>
        /// Calls OnStarted for each of the interactors
        /// </summary>
        public void InvokeOnStart() {
            foreach (var item in interactors) {
                item.Value.OnStarted();
            }
        }

        public T Get<T>() where T : Interactor {
            Type type = typeof(T);
            return (T)interactors[type];
        }
    }
}
