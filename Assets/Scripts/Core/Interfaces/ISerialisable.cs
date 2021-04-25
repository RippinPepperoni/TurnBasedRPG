using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface ISerialisable
    {
        void Deserialise(Data data);
        Data Serialise();
    }
}
