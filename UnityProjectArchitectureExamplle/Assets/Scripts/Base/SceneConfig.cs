using System;
using System.Collections.Generic;

namespace Base {
    public abstract class SceneConfig {

        public abstract string SceneName { get; }

        public abstract Dictionary<Type, Feature> CreateAllInteractors();

        public void CreateInteractor<T>(Dictionary<Type, Feature> features) where T : Feature, new() {
            T feature = new T();
            Type type = typeof(T);
            features[type] = feature;
        }
    }
}
