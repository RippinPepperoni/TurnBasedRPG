using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public enum PersistanceType
    {
        DoNotPersist,
        ReadOnly,
        WriteOnly,
        ReadWrite
    }

    [System.Serializable]
    public class DataSettings
    {
        public string UniqueID = System.Guid.NewGuid().ToString();
        public PersistanceType PersistanceType = PersistanceType.ReadWrite;
    }
}
