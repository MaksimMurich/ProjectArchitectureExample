using System;

namespace Base {
    public abstract class Feature {

        /// <summary>
        /// Calls after creatoin, before initialized
        /// </summary>
        public virtual void OnCreated() { }

        public virtual void Initialize() { }

        public virtual void OnStarted() { }
    }
}
