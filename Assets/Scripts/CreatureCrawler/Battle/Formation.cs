using System;
using System.Collections.Generic;

namespace CreatureCrawler.Battle {
    public class Formation {
        // 0 is the "front row", and the row numbers increase the farther back
        // a row is from battle
        public List<List<Guid>> Rows = new List<List<Guid>>();

        public void AddToRow(Guid monIdToAdd, int rowIndex) {
            if (Rows.Count < rowIndex + 1) {
                while (Rows.Count != rowIndex + 1) {
                    Rows.Add(new List<Guid>());
                }
            }
            Rows[rowIndex].Add(monIdToAdd);
        }
    }
}