using System.Collections.Generic;
using CreatureCrawler.Effects;

namespace CreatureCrawler {
    public class Mon {
        // Generic
        public string name = "";
        public Templates.MonTemplates template;
        public string id = "";

        // Battles
        public int formationIndex;
        public int rowIndex;
        public int hp;
        public List<MonEffect> effects = new List<MonEffect>();
    }
}