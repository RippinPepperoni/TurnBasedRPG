#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Summoner : Combatant, IPersistable
    {
        [SerializeField] private AttributeSet attributeSet;
        [SerializeField] private DataSettings dataSettings;

        private bool _isInitialised = false;

        private void Start()
        {
            if (!_isInitialised)
            {
                _isInitialised = true;
                Initialise();
            }
        }

        private void Initialise()
        {
            Affinity = Affinity.Friendly;

            Health = new Attribute(CalculateHealthAttributeValue(attributeSet.Health));
            Attack = new Attribute(CalculateAttributeValue(attributeSet.Attack));
            Defence = new Attribute(CalculateAttributeValue(attributeSet.Defence));
            Speed = new Attribute(CalculateAttributeValue(attributeSet.Speed));

            Abilities = attributeSet.Abilities;
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void Load(Data data)
        {
            var save = (Data<SaveData>)data;

            _isInitialised = save.Content.IsInitialised;

            Health = save.Content.Health;
            Attack = save.Content.Attack;
            Defence = save.Content.Defence;
            Speed = save.Content.Speed;

            Abilities = save.Content.Abilities;
        }

        public Data Save()
        {
            var save = new SaveData();

            save.IsInitialised = _isInitialised;

            save.Health = Health;
            save.Attack = Attack;
            save.Defence = Defence;
            save.Speed = Speed;

            save.Abilities = Abilities;

            return new Data<SaveData>(save);
        }

        internal struct SaveData
        {
            public bool IsInitialised { get; set; }

            public Attribute Health { get; set; }
            public Attribute Attack { get; set; }
            public Attribute Defence { get; set; }
            public Attribute Speed { get; set; }

            public Ability[] Abilities { get; set; }
        }
    }
}
