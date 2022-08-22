using System;
using System.Collections.Generic;
using System.Linq;
using CreatureCrawler.Effects;
using CreatureCrawler.Skills;
using CreatureCrawler.Suggestors;
using QFSW.QC;
using QFSW.QC.Actions;
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

        //  __  __  ____  _   _  _____             _____                           _
        // |  \/  |/ __ \| \ | |/ ____|           / ____|                         | |
        // | \  / | |  | |  \| | (___    ______  | |  __  ___ _ __   ___ _ __ __ _| |
        // | |\/| | |  | | . ` |\___ \  |______| | | |_ |/ _ \ '_ \ / _ \ '__/ _` | |
        // | |  | | |__| | |\  |____) |          | |__| |  __/ | | |  __/ | | (_| | |
        // |_|  |_|\____/|_| \_|_____/            \_____|\___|_| |_|\___|_|  \__,_|_|
        //

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
            var mons = _state.mons.Keys;
            if (mons.Count > 0) {
                var selectedMonId = "";
                yield return new Choice<string>(mons, choice => {
                    selectedMonId = choice;
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
                yield return new Value($"{mon.id}");
            }
        }

        // Displays all values of a given mon in the console
        [Command("get-mon")]
        public void GetMonCommand([MonInstanceSuggestorTag] string monId) {
            try {
                var foundMon = _state.mons[monId];
                Debug.Log(JsonUtility.ToJson(foundMon, true));
            }
            catch (Exception) {
                // suppress error
            }
        }

        //  __  __  ____  _   _  _____            ____        _   _   _
        // |  \/  |/ __ \| \ | |/ ____|          |  _ \      | | | | | |
        // | \  / | |  | |  \| | (___    ______  | |_) | __ _| |_| |_| | ___
        // | |\/| | |  | | . ` |\___ \  |______| |  _ < / _` | __| __| |/ _ \
        // | |  | | |__| | |\  |____) |          | |_) | (_| | |_| |_| |  __/
        // |_|  |_|\____/|_| \_|_____/           |____/ \__,_|\__|\__|_|\___|

        // Adds an effect to a mon and applied immediately - no strings attached
        [Command("add-effect")]
        public void AddEffectCommand(
            [MonEffectTemplateSuggestorTag] string effectName,
            [MonInstanceSuggestorTag] string ownerMonId,
            [MonInstanceSuggestorTag] string targetMonId
        ) {
            var context = new MonEffectContext {
                ownerMon = _state.mons[ownerMonId],
                targetMon = _state.mons[targetMonId],
                amount = 5,
            };
            var effect = new DamageEffect { context = context };
            _actions.ApplyEffect(effect);
        }
    }
}