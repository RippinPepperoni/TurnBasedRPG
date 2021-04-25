using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class SaveSystem : EntitySystem
    {
        private readonly HashSet<ISerialisable> _entites = new HashSet<ISerialisable>();

        public override void Initialise()
        {
            Filter = new Filter(typeof(Summoner));
        }

        public override void OnEntityAdded(IEntity entity)
        {
            if (entity.HasComponent(out ISerialisable component) && !_entites.Contains(component))
            {
                _entites.Add(component);
            }
        }

        public void Load()
        {
            
            foreach (var entity in _entites)
            {

            }
        }

        public void Save()
        {

        }
    }
}
