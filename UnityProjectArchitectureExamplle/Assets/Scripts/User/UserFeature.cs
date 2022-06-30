using Base;

namespace User {
    public class UserFeature : Feature {

        public int OpenAppCount => repository.OpenAppCount;

        private UserRepository repository;

        public UserFeature() {
            repository = new UserRepository();
        }

        public override void Initialize() {
            repository.Initialize();
            base.Initialize();
        }

        public override void OnCreated() {
            base.OnCreated();
        }

        public override void OnStarted() {
            base.OnStarted();
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
