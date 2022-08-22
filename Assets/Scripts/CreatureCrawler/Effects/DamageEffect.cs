using System;
using System.Collections.Generic;

namespace CreatureCrawler.Effects {
    [Serializable]
    public class DamageEffect : MonEffect {
        public DamageEffect() {
            triggers = new List<MonEffectTriggers> { MonEffectTriggers.OnApply };
            destroyTriggers = new List<MonEffectDestroyTriggers> { MonEffectDestroyTriggers.OnApply };
        }

        public override void onApply() {
            context.targetMon.hp -= (int) Math.Floor(context.amount);
        }
    }
}