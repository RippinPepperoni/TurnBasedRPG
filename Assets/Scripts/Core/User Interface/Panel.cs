using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public abstract class Panel : MonoBehaviour
    {
        public abstract void Initialise();

        public virtual void Show() => gameObject.SetActive(true);

        public virtual void Hide() => gameObject.SetActive(false);
    }
}
