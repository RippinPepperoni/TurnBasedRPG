#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedRPG
{
    public class MonsterPanel : Panel
    {
        [SerializeField] private Image image;

        public override void Initialise()
        {

        }

        public void Bind(Combatant combatant)
        {
            image.sprite = combatant.Sprite;
        }
    }
}
