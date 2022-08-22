using CreatureCrawler.Effects;

namespace CreatureCrawler.Skills {
    public class Tackle : MonSkill {
        public Tackle(Mon owner, Mon target) : base(owner, target) {

        }

        public override MonEffect generateEffect() {
            return new DamageEffect {
                context = new MonEffectContext {
                    ownerMon = owner,
                    targetMon = target,
                    amount = 5,
                },
            };
        }
    }
}