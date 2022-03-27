using System;
using System.Collections.Generic;
using CreatureCrawler.Suggestors;
using QFSW.QC;
using QFSW.QC.Actions;
using UnityEngine;

namespace CreatureCrawler {
    public class Commands : MonoBehaviour {
        private Actions _actions;

        public void Awake() {
            Debug.Log("Commands component is awake.");
        }

        public void Start() {
            _actions = GetComponent<Actions>();
            Debug.Log("Commands component is initialized.");
        }

        [Command("spawn-mon")]
        public IEnumerator<ICommandAction> SpawnMonCommand(
            [MonTemplateSuggestorTag] string monTemplateName,
            string monName
        ) {
            if (Enum.TryParse(monTemplateName, out Templates.MonTemplates monTemplate)) {
                _actions.SpawnMon(monTemplate, monName);
                yield return new Value($"Generated new {monTemplateName} named {monName}");
            }
            else {
                yield return new Value($"Could not find template with name {monTemplateName}");
            }
        }
    }
}