using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    internal struct AIConfig
    {
        public float Speed;
        public float MINDistanceToTarget;
        public Transform[] Waypoints;
    }
}
