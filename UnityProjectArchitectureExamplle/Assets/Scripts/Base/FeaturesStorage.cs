using System;
using System.Collections.Generic;
using User;

namespace Base {

    public class FeaturesStorage {

        private Dictionary<Type, Feature> features;

        private SceneConfig sceneConfig;

        public FeaturesStorage(SceneConfig sceneConfig) {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAll() {
            features = sceneConfig.CreateAllInteractors();
        }

        /// <summary>
        /// Calls OnCreated for each of the feature
        /// </summary>
        public void InvokeOnCreatedToAll() {
            foreach (var item in features) {
                item.Value.OnCreated();
            }
        }

        public void InitializeAll() {
            Initialize<UserFeature>();
        }

        public void Initialize<T>() where T : Feature, new() {
            features[typeof(T)].Initialize();
        }

        /// <summary>
        /// Calls OnStarted for each of the feature
        /// </summary>
        public void InvokeOnStart() {
            foreach (var item in features) {
                item.Value.OnStarted();
            }
        }

        public T Get<T>() where T : Feature {
            Type type = typeof(T);
            return (T)features[type];
        }
    }
}
