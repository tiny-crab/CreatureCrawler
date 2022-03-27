using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreatureCrawler {
    public class State : MonoBehaviour {
        public Dictionary<Guid, Mon> mons = new Dictionary<Guid, Mon>();
        
        public void Awake() {
            Debug.Log("State component is awake.");
        }
        
        public void Start() {
            Debug.Log("State component is initialized.");
        }
    }
}