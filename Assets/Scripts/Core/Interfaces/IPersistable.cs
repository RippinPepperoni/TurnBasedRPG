using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IPersistable
    {
        void Load(Data data);
        Data Save();

        DataSettings GetDataSettings();
    }
}
