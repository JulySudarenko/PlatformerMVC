using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class DamagingObjects
    {
        public List<int> AllDamagingObjects { get; }

        public DamagingObjects()
        {
            AllDamagingObjects = new List<int>();
        }

        public void AddDamagingObject(int newObject)
        {
            AllDamagingObjects.Add(newObject);
        }
    }
}
