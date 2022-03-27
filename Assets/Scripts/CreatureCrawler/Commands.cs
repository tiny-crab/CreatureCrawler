using System;
using System.Collections.Generic;
using System.Linq;
using CreatureCrawler.Suggestors;
using QFSW.QC;
using QFSW.QC.Actions;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace CreatureCrawler {
    public class Commands : MonoBehaviour {
        private Actions _actions;
        private State _state;

        public void Awake() {
            Debug.Log("Commands component is awake.");
        }

        public void Start() {
            _actions = GetComponent<Actions>();
            _state = GetComponent<State>();
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

        [Command("summon-mon")]
        public IEnumerator<ICommandAction> SummonMonCommand() {
            var mons = _state.Mons.Values.ToDictionary(m => m.Name, m => m.Id);
            if (mons.Count > 0) {
                var selectedMonId = new Guid();
                yield return new Choice<string>(mons.Keys, choice => {
                    selectedMonId = mons[choice];
                });

                var selectedFormation = 0;
                yield return new Choice<int>(Enumerable.Range(0, 2), choice => {
                    selectedFormation = choice;
                });

                var selectedRow = 0;
                yield return new Choice<int>(Enumerable.Range(0, 3), choice => {
                    selectedRow = choice;
                });

                _actions.SummonMon(selectedMonId, selectedFormation, selectedRow);
            }
            else {
                yield return new Value("Run spawn-mon before summon-mon.");
            }

        }

        [Command("list-mons")]
        public IEnumerator<ICommandAction> ListMonsCommand() {
            foreach (var mon in _state.Mons.Values) {
                yield return new Value($"{mon.Name}");
            }
        }
    }
}