using System;
using System.Collections.Generic;

namespace Base {
    public abstract class SceneConfig {

        public abstract string SceneName { get; }

        public abstract Dictionary<Type, Interactor> CreateAllInteractors();
        public abstract Dictionary<Type, Repository> CreateAllRepositories();

        public void CreateInteractor<T>(Dictionary<Type, Interactor> interactors) where T : Interactor, new() {
            T interactor = new T();
            Type type = typeof(T);
            interactors[type] = interactor;
        }

        public void CreateRepository<T>(Dictionary<Type, Repository> repositories) where T : Repository, new() {
            T repository = new T();
            Type type = typeof(T);
            repositories[type] = repository;
        }
    }
}
