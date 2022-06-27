using System;
using System.Collections.Generic;
using User;

namespace Base {
    public class RepositoriesStorage {

        private Dictionary<Type, Repository> repositories;

        public RepositoriesStorage() {
            repositories = new Dictionary<Type, Repository>();
        }

        public void CreateAll() {
            CreateRepository<UserRepository>();
        }

        public void CreateRepository<T>() where T : Repository, new() {
            T repository = new T();
            Type type = repository.GetType();
            repositories.Add(type, repository);
        }

        /// <summary>
        /// Calls OnCreated for each of the repositories
        /// </summary>
        public void SendOnCreatedToAll() {
            foreach (var item in repositories) {
                item.Value.OnCreated();
            }
        }

        //@TODO upgrade to coroutin for doing long time processes for loading or external services initialization
        public void InitializeAll() {
            Initialize<UserRepository>();
        }

        public void Initialize<T>() where T : Repository, new() {
            repositories[typeof(T)].Initialize();
        }

        /// <summary>
        /// Calls OnStarted for each of the repositories
        /// </summary>
        public void InvokeOnStarted() {
            foreach (var item in repositories) {
                item.Value.OnStarted();
            }
        }

        public T GetRepository<T>() where T : Repository {
            Type type = typeof(T);
            return (T)repositories[type];
        }
    }
}
