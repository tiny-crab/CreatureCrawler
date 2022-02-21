using System.Collections.Generic;
using QFSW.QC;
using QFSW.QC.Actions;
using UnityEngine;

namespace CreatureCrawler {
    public class GameActions : MonoBehaviour {

        private GameState _gameState;
        public void Start() {
            _gameState = GetComponent<GameState>();
        }
        
        [Command("update-counter")]
        public IEnumerator<ICommandAction> UpdateCounter() {
            _gameState.counter++;
            yield return new Typewriter($"counter updated to {_gameState.counter}");
        }
    }
}