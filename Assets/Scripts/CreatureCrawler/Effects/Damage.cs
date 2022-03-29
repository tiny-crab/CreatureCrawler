using System;
using System.Collections.Generic;

namespace CreatureCrawler.Effects {
    [Serializable]
    public class Damage : MonEffect {
        public new List<MonEffectTriggers> triggers = new List<MonEffectTriggers> {
            MonEffectTriggers.OnApply
        };

        public override void onApply() {
            context.targetMon.hp -= (int) Math.Floor(context.amount);
        }
    }
}