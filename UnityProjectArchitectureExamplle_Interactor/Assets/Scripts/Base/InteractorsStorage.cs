using System;
using System.Collections.Generic;
using User;

namespace Base {

    public class InteractorsStorage {

        private Dictionary<Type, Interactor> interactors;

        public InteractorsStorage() {
            interactors = new Dictionary<Type, Interactor>();
        }

        public void CreateAll() {
            CreateInteractor<UserInteractor>();
        }

        public void CreateInteractor<T>() where T : Interactor, new() {
            T interactor = new T();
            Type type = interactor.GetType();
            interactors.Add(type, interactor);
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

        public T GetInteractor<T>() where T : Interactor {
            Type type = typeof(T);
            return (T)interactors[type];
        }
    }
}
