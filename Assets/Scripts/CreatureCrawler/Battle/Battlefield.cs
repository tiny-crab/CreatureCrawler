using System;
using System.Collections.Generic;

namespace CreatureCrawler.Battle {
    public class Battlefield {
        public List<Formation> Formations = new List<Formation>();

        public void AddToFormation(
            Guid monId,
            int formationIndex,
            int rowIndex
        ) {
            if (Formations.Count < formationIndex + 1) {
                while (Formations.Count != formationIndex + 1) {
                    Formations.Add(new Formation());
                }
            }
            Formations[formationIndex].AddToRow(monId, rowIndex);
        }
    }
}