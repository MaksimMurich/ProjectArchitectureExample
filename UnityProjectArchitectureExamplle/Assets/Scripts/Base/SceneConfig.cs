using System;
using System.Collections.Generic;

namespace Base {
    public abstract class SceneConfig {

        public abstract string SceneName { get; }

        public abstract Dictionary<Type, Feature> CreateAllFeatures();

        public void CreateFeature<T>(Dictionary<Type, Feature> features) where T : Feature, new() {
            T feature = new T();
            Type type = typeof(T);
            features[type] = feature;
        }
    }
}
