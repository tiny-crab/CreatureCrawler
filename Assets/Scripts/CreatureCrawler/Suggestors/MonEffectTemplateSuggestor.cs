using System;
using System.Collections.Generic;
using System.Linq;
using CreatureCrawler.Effects;
using QFSW.QC;

namespace CreatureCrawler.Suggestors {
    public struct MonEffectTemplateSuggestorTag : IQcSuggestorTag { }

    public sealed class MonEffectTemplateSuggestorTagAttribute : SuggestorTagAttribute
    {
        private readonly IQcSuggestorTag[] _tags = { new MonEffectTemplateSuggestorTag() };

        public override IQcSuggestorTag[] GetSuggestorTags()
        {
            return _tags;
        }
    }

    public class MonEffectTemplateSuggestor : BasicCachedQcSuggestor<string>
    {
        protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
        {
            return context.HasTag<MonEffectTemplateSuggestorTag>();
        }

        protected override IQcSuggestion ItemToSuggestion(string abilityName)
        {
            return new RawSuggestion(abilityName, true);
        }

        protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options) {
            var effectType = typeof(MonEffect);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => effectType.IsAssignableFrom(p) && !p.IsAbstract)
                .Select(p => p.Name);
        }
    }

}