using System;
using System.Collections.Generic;

namespace CreatureCrawler {
    public class Mon {
        // Generic
        public string name = "";
        public Templates.MonTemplates template;
        public Guid id = Guid.NewGuid();

        // Battles
        public int formationIndex;
        public int rowIndex;
    }

    public class Battlefield {
        public List<Formation> formations = new List<Formation>();
    }

    public class Formation {
        public int index;
        public List<Row> rows = new List<Row>();
    }

    public class Row {
        public int index;
    }
}