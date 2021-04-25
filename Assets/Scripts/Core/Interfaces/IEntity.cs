using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IEntity
    {
        bool HasComponent<T>(out T component);
        bool HasComponent<T1, T2>(out T1 componentOne, out T2 componentTwo);
    }
}
