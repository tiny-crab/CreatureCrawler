using System.Linq;
using CreatureCrawler;
using CreatureCrawler.Events;
using UniRx;
using UnityEngine;

public class MouseAndKeyboard : MonoBehaviour {

    private State _state;

    void Start() {
        _state = GetComponent<State>();

        var clickStream = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0));

        clickStream.Subscribe(clickEvent => {
            var worldCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hits = Physics2D.CircleCastAll(worldCoord, 0.1f, Vector2.zero);
            var clickables = hits.Select(i => i.collider.gameObject).Where(i => i.CompareTag(GOTags.Clickable)).ToList();
            foreach (var clicked in clickables) {
                _state.eventStream.Publish(new ClickEvent {
                    clicked = clicked
                });
            }
        });
    }
}
