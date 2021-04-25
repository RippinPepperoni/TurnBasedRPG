#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum CombatState
    {
        Begin,
        Wait,
        Execute,
        Won,
        Lost
    }

    public class CombatSystem : MonoBehaviour
    {
        [SerializeField] public CombatPanelLayout CombatPanelLayout;
        [SerializeField] public Typewriter Typewriter;

        [SerializeField] public Combatant Player;
        [SerializeField] public Combatant Monster;

        public readonly List<IAction> Actions = new List<IAction>();

        private StateMachine<CombatState> _stateMachine;

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            var stateList = new List<IState<CombatState>>()
            {
                new CombatBeginState<CombatState>(CombatState.Begin, this),
                new CombatWaitState<CombatState>(CombatState.Wait, this),
                new CombatExecuteState<CombatState>(CombatState.Execute, this),
                new CombatWonState<CombatState>(CombatState.Won, this),
                new CombatLostState<CombatState>(CombatState.Lost)
            };

            _stateMachine = new StateMachine<CombatState>(stateList.ToArray(), CombatState.Begin);
        }

        private void Start()
        {
            _stateMachine.OnEnter();
        }

        public void SetInterfaceText(string text)
        {
            Typewriter.Text = text;
        }

        public void ChangeState(CombatState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void OnTalkSelected()
        {

        }

        public void OnAbilitySelected(int index)
        {
            Actions.Add(new Attack(Player.Abilities[index], this, Monster, Player));
            Actions.Add(new Attack(Monster.Abilities[0], this, Player, Monster));

            ChangeState(CombatState.Execute);
        }

        private void OnDestroy()
        {
            _stateMachine.Dispose();
        }
    }
}
