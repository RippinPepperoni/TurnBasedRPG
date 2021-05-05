using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IInput
    {
        Vector2 Input { get; set; }
        Vector2 Direction { get; set; }
    }
}
