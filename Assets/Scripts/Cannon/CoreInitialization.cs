using UnityEngine;

namespace Platformer
{
    public class CoreInitialization
    {
        private ICoreFactory _coreFactory;
        private GameObject _core;

        public CoreInitialization(ICoreFactory coreFactory)
        {
            _coreFactory = coreFactory;
        }
        
        public GameObject CreateCore()
        {
            _core = _coreFactory.CreateCore();
            return _core;
        }
    }
}
