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

    public enum MonEffectDestroyTriggers {
        OnApply,
        OnAmountZero,
    }

    [Serializable]
    public abstract class MonEffect {
        public MonEffectContext context { get; set; }
        public bool destroyed { get; set; }
        public List<MonEffectTriggers> triggers { get; set; }
        public List<MonEffectDestroyTriggers> destroyTriggers { get; set; }
        public virtual void onTurnStart() {}
        public virtual void onApply() {}
        public virtual void onTurnEnd() {}
    }
}