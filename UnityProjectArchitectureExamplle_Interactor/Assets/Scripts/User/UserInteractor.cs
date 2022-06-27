using Base;
using User.View;

namespace User {
    public class UserInteractor : Interactor {

        public int OpenAppCount => repository.OpenAppCount;

        private UserRepository repository;

        public UserInteractor() {
        }

        public bool IsFirstOpen() {
            return OpenAppCount == 1;
        }

        public bool IsSkilled() {
            return OpenAppCount > 5;
        }

        public void AddOpenAppCount() {
            repository.OpenAppCount++;
            repository.Save();
        }

        public override void OnCreated() {
            base.OnCreated();
            repository = TestArchitecture.repositoriesStorage.GetRepository<UserRepository>();
        }

        public override void OnStarted() {
            base.OnStarted();

        }
    }
}
