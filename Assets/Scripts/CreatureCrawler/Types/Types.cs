using System;

namespace CreatureCrawler {
    public class Mon {
        public string Name = "";
        public Templates.MonTemplates Template;
        public Guid Id = Guid.NewGuid();
    }
}