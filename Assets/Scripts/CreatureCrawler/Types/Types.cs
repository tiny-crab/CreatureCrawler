using System;
using System.Collections.Generic;
using CreatureCrawler.Effects;

namespace CreatureCrawler {
    [Serializable]
    public class Mon {
        // Generic
        public string name = "";
        public Templates.MonTemplates template;
        public string id = "";

        // Battles
        public int formationIndex;
        public int rowIndex;
        public int hp;
    }

    [Serializable]
    public class Battlefield {
        public List<MonEffect> monEffectsQueue = new List<MonEffect>();
        public List<Formation> formations = new List<Formation>();
    }

    [Serializable]
    public class Formation {
        public int index;
        public List<Row> rows = new List<Row>();
    }

    [Serializable]
    public class Row {
        public int index;
    }
}