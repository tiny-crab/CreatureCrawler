using CreatureCrawler.Utils;
using UnityEngine;

namespace CreatureCrawler {
    public class Game : MonoBehaviour {
        public State State;

        public void Awake() {
            Debug.Log("Game component is awake.");
            State = gameObject.AddAndGetComponent<State>();
            gameObject.AddComponent<MouseAndKeyboard>();
        }
    }
}