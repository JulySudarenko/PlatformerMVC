using System.Collections.Generic;

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

        public void AddManyDamagingObject(int[] newObjects)
        {
            for (int i = 0; i < newObjects.Length; i++)
            {
                AllDamagingObjects.Add(newObjects[i]);
            }
        }
    }
}
