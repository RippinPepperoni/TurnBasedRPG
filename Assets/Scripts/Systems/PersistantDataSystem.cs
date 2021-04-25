using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class PersistantDataSystem : EntitySystem
    {
        private readonly SystemComponents<IPersistable> _components = new SystemComponents<IPersistable>();
        private readonly Dictionary<string, Data> _data = new Dictionary<string, Data>();

        public override void Initialise()
        {
            Filter = new Filter(typeof(Summoner));
        }

        public override void OnEntityAdded(IEntity entity)
        {
            _components.Add(entity);
        }

        public void LoadAllDataInternal()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                Load(_components[i]);
            }
        }

        public void Load(IPersistable entry)
        {
            DataSettings settings = entry.GetDataSettings();

            if (settings.PersistanceType == PersistanceType.ReadOnly || settings.PersistanceType == PersistanceType.ReadWrite)
            {
                string uniqueID = settings.UniqueID;

                if (!string.IsNullOrEmpty(uniqueID) && _data.ContainsKey(uniqueID))
                {
                    entry.Load(_data[uniqueID]);
                }
            }
        }

        public void SaveAllDataInternal()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                Save(_components[i]);
            }
        }

        public void Save(IPersistable entry)
        {
            DataSettings dataSettings = entry.GetDataSettings();

            if (dataSettings.PersistanceType == PersistanceType.WriteOnly || dataSettings.PersistanceType == PersistanceType.ReadWrite)
            {
                string uniqueID = dataSettings.UniqueID;

                if (!string.IsNullOrEmpty(uniqueID))
                {
                    _data[uniqueID] = entry.Save();
                }
            }
        }

        public override void OnEntityRemoved(IEntity entity)
        {
            _components.Remove(entity);
        }
    }
}
