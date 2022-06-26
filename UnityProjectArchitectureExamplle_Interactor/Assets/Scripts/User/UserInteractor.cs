using Base;

namespace User {
    public class UserInteractor : Interactor {

        public int OpenAppCount => repository.OpenAppCount;

        private UserRepository repository;

        public UserInteractor(UserRepository repository) {
            this.repository = repository;
            this.repository.Initialize();
        }

        public override void Initialize() {
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
    }
}
