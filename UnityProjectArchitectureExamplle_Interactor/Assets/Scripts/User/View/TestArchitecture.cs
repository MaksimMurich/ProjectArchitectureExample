using Base;
using System.Collections;
using UnityEngine;

namespace User.View {
    public class TestArchitecture : MonoBehaviour{

        public static RepositoriesStorage repositoriesStorage;
        public static InteractorsStorage interactoraStorage;

        [SerializeField] private TMPro.TMP_Text openAppCount;

        private void Start() {
            StartCoroutine(StartGameRoutine());
        }

        public IEnumerator StartGameRoutine() {

            repositoriesStorage = new RepositoriesStorage();
            interactoraStorage = new InteractorsStorage();

            repositoriesStorage.CreateAll();
            interactoraStorage.CreateAll();

            yield return null;

            repositoriesStorage.SendOnCreatedToAll();
            interactoraStorage.InvokeOnCreatedToAll();

            yield return null;

            repositoriesStorage.InitializeAll();
            interactoraStorage.InitializeAll();

            yield return null;

            repositoriesStorage.InvokeOnStarted();
            interactoraStorage.InvokeOnStart();

            //Test invoke userInteractor API
            UserInteractor userInteractor = interactoraStorage.GetInteractor<UserInteractor>();
            userInteractor.AddOpenAppCount();
            openAppCount.text = userInteractor.OpenAppCount.ToString();
        }
    }
}
