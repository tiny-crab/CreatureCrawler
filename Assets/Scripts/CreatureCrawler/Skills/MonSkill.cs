using CreatureCrawler.Effects;

namespace CreatureCrawler.Skills {
    public abstract class MonSkill {
        public Mon owner;
        public Mon target;

        protected MonSkill(Mon owner, Mon target) {
            this.owner = owner;
            this.target = target;
        }
        public abstract MonEffect generateEffect();
    }
}