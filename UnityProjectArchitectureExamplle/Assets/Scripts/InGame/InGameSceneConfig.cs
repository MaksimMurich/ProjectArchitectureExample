using Base;
using System;
using System.Collections.Generic;

namespace InGame {
    public class InGameSceneConfig : SceneConfig {

        public const string SCENE_NAME = "InGame";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Feature> CreateAllInteractors() {

            Dictionary<Type, Feature> features = new Dictionary<Type, Feature>();

            CreateInteractor<User.UserFeature>(features);

            return features;
        }
    }
}
