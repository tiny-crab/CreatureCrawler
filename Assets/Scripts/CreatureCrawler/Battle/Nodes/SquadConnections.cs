using CreatureCrawler.Events;
using UniRx;
using UnityEngine;

namespace CreatureCrawler.Battle.Nodes {
    public class SquadConnections {
        public SquadConnections(Game game) {
            Debug.Log("setting up squadconnections");
            var nodeClickedEvents = game.State.eventStream.Receive<ClickEvent>()
                .Where(clickEvent => clickEvent.clicked.gameObject.GetComponent<ConnectionCollider>() != null);

            nodeClickedEvents.Subscribe(_ => Debug.Log("node clicked"));
        }
    }
}