using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public struct Easing
    {
        public static float Linear(float time)
        {
            return time;
        }

        public static float EaseOutSine(float time)
        {
            return Mathf.Sin((time * Mathf.PI) / 2f);
        }

        public static float EaseOutBounce(float time)
        {
            if (time < (1f / 2.75f))
            {
                return 7.5625f * time * time;
            }
            else if (time < (2f / 2.75f))
            {
                return 7.5625f * (time -= 1.5f / 2.75f) * time + 0.75f;
            }
            else if (time < (2.5f / 2.75f))
            {
                return 7.5625f * (time -= 2.25f / 2.75f) * time + 0.9375f;
            }
            else
            {
                return 7.5625f * (time -= 2.625f / 2.75f) * time + 0.984375f;
            }
        }

        public static float PingPong(float time)
        {
            return Mathf.PingPong(time * 2f, 1f);
        }
    }
}
