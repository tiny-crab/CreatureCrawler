using System;
using System.Collections.Generic;
using CreatureCrawler.Battle;
using UnityEngine;

namespace CreatureCrawler {
    public class State : MonoBehaviour {
        public Battlefield Battlefield = new Battlefield();
        public Dictionary<Guid, Mon> Mons = new Dictionary<Guid, Mon>();

        public void Awake() {
            Debug.Log("State component is awake.");
        }

        public void Start() {
            Debug.Log("State component is initialized.");
        }
    }
}