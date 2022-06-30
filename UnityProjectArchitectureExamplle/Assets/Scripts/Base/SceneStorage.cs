using System.Collections;

namespace Base {
    public class SceneStorage {

        public bool IsInitialized = false;

        private FeaturesStorage features;

        public SceneStorage(SceneConfig config) {
            features = new FeaturesStorage(config);
        }

        //@TODO public coroutine is bad
        public IEnumerator Initialize() {

            features.CreateAll();

            yield return null;

            features.InvokeOnCreatedToAll();

            yield return null;

            features.InitializeAll();
            IsInitialized = true;

            yield return null;

            features.InvokeOnStart();
        }

        public T GetFeature<T>() where T : Feature, new() {
            return features.Get<T>();
        }
    }
}
