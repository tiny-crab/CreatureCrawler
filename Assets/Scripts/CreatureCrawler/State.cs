using System.Collections.Generic;
using CreatureCrawler.Battle;
using UniRx;
using UnityEngine;

namespace CreatureCrawler {
    public class State : MonoBehaviour {
        public BattlefieldLogic battlefieldLogic = new BattlefieldLogic();
        public Dictionary<string, Mon> mons = new Dictionary<string, Mon>();

        public MessageBroker eventStream = new MessageBroker();

        public void Awake() {
            Debug.Log("State component is awake.");
        }

        public void Start() {
            Debug.Log("State component is initialized.");
        }
    }
}