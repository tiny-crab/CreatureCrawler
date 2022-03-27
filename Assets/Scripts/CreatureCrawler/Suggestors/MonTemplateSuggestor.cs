using System;
using System.Collections.Generic;
using QFSW.QC;

namespace CreatureCrawler.Suggestors {
    public struct MonTemplateSuggestorTag : IQcSuggestorTag { }
    
    public sealed class MonTemplateSuggestorTagAttribute : SuggestorTagAttribute
    {
        private readonly IQcSuggestorTag[] _tags = { new MonTemplateSuggestorTag() };

        public override IQcSuggestorTag[] GetSuggestorTags()
        {
            return _tags;
        }
    }
    
    public class MonTemplateSuggestor : BasicCachedQcSuggestor<string>
    {
        protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
        {
            return context.HasTag<MonTemplateSuggestorTag>();
        }

        protected override IQcSuggestion ItemToSuggestion(string abilityName)
        {
            return new RawSuggestion(abilityName, true);
        }

        protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options) {
            return Enum.GetNames(typeof(Templates.MonTemplates));
        }
    }
    
}