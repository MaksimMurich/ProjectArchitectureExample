using System.Collections;
using UnityEngine;

namespace Base {
    public sealed class Coroutines : MonoBehaviour {

        private static Coroutines Instance {
            get {
                if (instance == null) {
                    GameObject gameObject = new GameObject("[CoroutinesManager]");
                    instance = gameObject.AddComponent<Coroutines>();
                    DontDestroyOnLoad(instance);
                }
                return instance;
            }
        }

        private static Coroutines instance;

        public static Coroutine _StartCoroutine(IEnumerator enumerator) {
            return Instance.StartCoroutine(enumerator);
        }

        public static void _StopCoroutine(Coroutine coroutine) {
            instance.StopCoroutine(coroutine);
        }
    }
}
