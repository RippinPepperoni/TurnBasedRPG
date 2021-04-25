using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class Data
    {

    }

    public class Data<T> : Data
    {
        public readonly T Content;

        public Data(T value)
        {
            Content = value;
        }
    }
}
