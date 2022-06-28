using Base;
using System;
using System.Collections.Generic;

namespace InGame {
    public class InGameSceneConfig : SceneConfig {

        public const string SCENE_NAME = "InGame";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Interactor> CreateAllInteractors() {

            Dictionary<Type, Interactor> interactors = new Dictionary<Type, Interactor>();

            CreateInteractor<User.UserInteractor>(interactors);

            return interactors;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories() {

            Dictionary<Type, Repository> repositories = new Dictionary<Type, Repository>();

            CreateRepository<User.UserRepository>(repositories);

            return repositories;
        }
    }
}
