using UnityEngine;

namespace Platformer
{
    internal class InitializeObject
    {
        private readonly IFactory _factory;

        public InitializeObject(IFactory factory)
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
