using UnityEngine;

namespace Platformer
{
    public class CoreFactory : ICoreFactory
    {
        private CannonConfig _config;

        public CoreFactory(CannonConfig config)
        {
            _config = config;
        }
        
        public GameObject CreateCore()
        {
            return Object.Instantiate(_config.CorePrefab);
        }
        

    }
}
