using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public interface IInteractable
    {
        bool CanInteract();
        object Interact();
    }
}
