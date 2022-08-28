using CreatureCrawler.Battle.Nodes;
using CreatureCrawler.Utils;
using UnityEngine;

namespace CreatureCrawler.Battle {
    public class Battlefield : MonoBehaviour {
        private SquadConnections _squadConnections;
        private Game _game;

        void Awake() {
            Debug.Log("Battlefield component is awake.");
            _game = GameObject.Find("Game").GetComponent<Game>();

            _squadConnections = new SquadConnections(_game);
        }
    }
}
