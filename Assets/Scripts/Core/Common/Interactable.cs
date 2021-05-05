using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class Interactable : EntityComponent, IInteractable
    {
        public static Event<Interactable> OnInteract { get; } = new Event<Interactable>();

        public abstract bool CanInteract();
        public abstract object Interact();
    }
}
