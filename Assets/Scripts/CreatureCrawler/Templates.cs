using System;
using System.Collections.Generic;

namespace CreatureCrawler {
    public class Templates {
        public enum MonTemplates {
            Charmander,
        }

        public static Dictionary<MonTemplates, Func<Mon>> mons = new Dictionary<MonTemplates, Func<Mon>> {
            { MonTemplates.Charmander , () => new Mon {
                template = MonTemplates.Charmander,
            }}
        };
    }
}