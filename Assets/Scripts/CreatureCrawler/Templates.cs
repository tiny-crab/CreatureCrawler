using System;
using System.Collections.Generic;

namespace CreatureCrawler {
    public class Templates {
        public enum MonTemplates {
            Bulbasaur,
            Charmander,
            Squirtle,
        }

        public static Dictionary<MonTemplates, Func<Mon>> mons = new Dictionary<MonTemplates, Func<Mon>> {
            { MonTemplates.Bulbasaur, () => new Mon {
                template = MonTemplates.Bulbasaur,
            }},
            { MonTemplates.Charmander, () => new Mon {
                template = MonTemplates.Charmander,
            }},
            { MonTemplates.Squirtle, () => new Mon {
                template = MonTemplates.Squirtle,
            }},
        };
    }
}