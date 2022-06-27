using Base;
using System;
using UnityEngine;

namespace User {
    public class UserRepository : Repository {

        public const string OPEN_APP_COUNT_KEY = "OPEN_APP_COUNT";

        public int OpenAppCount;

        public override void Initialize() {
            OpenAppCount = PlayerPrefs.GetInt(OPEN_APP_COUNT_KEY);
        }

        public override void OnCreated() {}

        public override void OnStarted() {}

        public override void Save() {
            PlayerPrefs.SetInt(OPEN_APP_COUNT_KEY, OpenAppCount);
        }
    }
}
