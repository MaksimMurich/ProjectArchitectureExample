namespace Base {
    public abstract class Repository {

        /// <summary>
        /// Calls after creatoin, before initialized
        /// </summary>
        public abstract void OnCreated();

        //@TODO upgrade to coroutin for doing long time processes for loading or external services initialization
        /// <summary>
        /// invoke after OnCreated
        /// </summary>
        public abstract void Initialize();
        public abstract void OnStarted();
        public abstract void Save();
    }
}
