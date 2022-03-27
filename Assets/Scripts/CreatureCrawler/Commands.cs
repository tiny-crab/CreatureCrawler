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

        // Use this to spawn a new mon
        // This will persist a mon instance throughout battles (part of the player's "inventory")
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

        // Use this to bring a mon instance from "inventory" to the actual battle space
        // Needs a mon to be spawned already in order to summon a specific mon instance
        [Command("summon-mon")]
        public IEnumerator<ICommandAction> SummonMonCommand() {
            var mons = _state.mons.Values.ToDictionary(m => m.name, m => m.id);
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

        // List all mon instances spawned so far
        [Command("list-mons")]
        public IEnumerator<ICommandAction> ListMonsCommand() {
            foreach (var mon in _state.mons.Values) {
                yield return new Value($"{mon.name}");
            }
        }
    }
}