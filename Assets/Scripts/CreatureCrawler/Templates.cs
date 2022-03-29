using System;
using System.Collections.Generic;
using CreatureCrawler.Effects;

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
                hp = 10,
            }},
            { MonTemplates.Charmander, () => new Mon {
                template = MonTemplates.Charmander,
                hp = 8,
            }},
            { MonTemplates.Squirtle, () => new Mon {
                template = MonTemplates.Squirtle,
                hp = 12,
            }},
        };
    }
}