using System;
using System.Collections.Generic;

namespace CreatureCrawler {

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