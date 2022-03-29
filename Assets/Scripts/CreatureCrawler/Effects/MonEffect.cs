using System;
using System.Collections.Generic;

namespace CreatureCrawler.Effects {
    [Serializable]
    public class MonEffectContext {
        public Mon ownerMon;
        public Mon targetMon;
        public double amount;
    }

    public enum MonEffectTriggers {
        OnTurnStart,
        OnApply,
        OnTurnEnd,
    }

    [Serializable]
    public abstract class MonEffect {
        public MonEffectContext context = null;
        public List<MonEffectTriggers> triggers = new List<MonEffectTriggers>();
        public virtual void onTurnStart() {}
        public virtual void onApply() {}
        public virtual void onTurnEnd() {}
    }
}