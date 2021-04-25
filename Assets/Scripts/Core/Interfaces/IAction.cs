using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IAction
    {
        IEnumerator Execute();
    }
}
