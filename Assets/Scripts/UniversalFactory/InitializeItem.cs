using UnityEngine;

namespace Platformer
{
    internal class InitializeItem
    {
        private readonly IFactory _factory;

        public InitializeItem(IFactory factory)
        {
            _factory = factory;
        }

        public Transform Create()
        {
            var newObject = _factory.Create();
            return newObject.transform;
        }
    }
}
