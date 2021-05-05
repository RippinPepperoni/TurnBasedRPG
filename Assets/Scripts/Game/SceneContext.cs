using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    [System.Serializable]
    public class SceneContext
    {
        [SerializeField] public string SceneName;
        [SerializeField] public Bounds Bounds;
    }
}
