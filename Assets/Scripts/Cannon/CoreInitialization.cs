using UnityEngine;

namespace Platformer
{
    public class CoreInitialization
    {
        private ICoreFactory _coreFactory;
        private GameObject _core;
        private SpriteRenderer _spriteRenderer;
        private TrailRenderer _trail;
        public Collider2D Collider;
        public Rigidbody2D Rigidbody;

        public CoreInitialization(ICoreFactory coreFactory)
        {
            _coreFactory = coreFactory;
            // _core = _coreFactory.CreateCore();
            // Transform = _core.transform;
        }
        
        public GameObject CreateCore()
        {
            _core = _coreFactory.CreateCore();
            _spriteRenderer = _core.GetComponentInChildren<SpriteRenderer>();
            _trail = _core.GetComponentInChildren<TrailRenderer>();
            Collider = _core.GetOrAddComponent<Collider2D>();
            Rigidbody = _core.GetOrAddComponent<Rigidbody2D>();
            return _core;
        }
        
        // public void SetVisible(bool visible)
        // {
        //     if (_trail) _trail.enabled = visible;
        //    if (_trail) _trail.Clear();
        //     _spriteRenderer.enabled = visible;
        //     var spriteRendererIsVisible = _spriteRenderer.isVisible;
        //     var tr = _trail.isVisible;
        //     Debug.Log(spriteRendererIsVisible);
        //     Debug.Log(tr);
        // }
    }
}
