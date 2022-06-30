namespace Base {
    public abstract class Repository {


        //@TODO upgrade to coroutin for doing long time processes for loading or external services initialization
        /// <summary>
        /// invoke after OnCreated
        /// </summary>
        public abstract void Initialize();
        public abstract void Save();
    }
}
