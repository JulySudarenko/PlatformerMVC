using System;
using UnityEngine;


namespace Platformer
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MINDistanceToTarget;
        public Transform[] Waypoints;
    }
}
