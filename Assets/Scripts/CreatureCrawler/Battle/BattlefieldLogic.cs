using System;
using System.Collections.Generic;
using CreatureCrawler.Effects;
using CreatureCrawler.Skills;

namespace CreatureCrawler.Battle {
    [Serializable]
    public class BattlefieldLogic {
        public List<MonSkill> monSkillsQueue = new List<MonSkill>();
        public List<Formation> formations = new List<Formation>();

        public void applyEffect(MonEffect effect) {
            // TODO modulate effect from owner, but in a higher method that calls this one
            // TODO modulate effect from target, same as above TODO
            // the reason this should be separate, is because we want the debug command
            // to attach the final state of an effect to a mon, nothing else.
            // the target mon's effects should not defend against this effect

            if (effect.triggers.Contains(MonEffectTriggers.OnApply)) {
                effect.onApply();
                if (effect.destroyTriggers.Contains(MonEffectDestroyTriggers.OnApply)) {
                    effect.destroyed = true;
                }
            }

            if (!effect.destroyed) {
                effect.context.targetMon.effects.Add(effect);
            }
        }
    }
}