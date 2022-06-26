using UnityEngine;

namespace User.View {
    public class UserPanel : MonoBehaviour{

        [SerializeField] private TMPro.TMP_Text openAppCount;

        private UserInteractor interactor;

        private void Start() {
            interactor = new UserInteractor(new UserRepository());
            interactor.Initialize();
            interactor.AddOpenAppCount();
            openAppCount.text = interactor.OpenAppCount.ToString();
        }
    }
}
