using System;
using System.Collections.Generic;
using System.Linq;
using QFSW.QC;
using UnityEngine;

namespace CreatureCrawler.Suggestors {
    public struct MonInstanceSuggestorTag : IQcSuggestorTag { }

    public sealed class MonInstanceSuggestorTagAttribute : SuggestorTagAttribute
    {
        private readonly IQcSuggestorTag[] _tags = { new MonInstanceSuggestorTag() };

        public override IQcSuggestorTag[] GetSuggestorTags()
        {
            return _tags;
        }
    }

    public class MonInstanceSuggestor : BasicCachedQcSuggestor<string>
    {
        protected override bool CanProvideSuggestions(SuggestionContext context, SuggestorOptions options)
        {
            return context.HasTag<MonInstanceSuggestorTag>();
        }

        protected override IQcSuggestion ItemToSuggestion(string abilityName)
        {
            return new RawSuggestion(abilityName, true);
        }

        protected override IEnumerable<string> GetItems(SuggestionContext context, SuggestorOptions options) {
            var state = GameObject.Find("Game").GetComponent<State>();
            return state.mons.Keys;
        }
    }

}