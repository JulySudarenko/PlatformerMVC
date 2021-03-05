using UnityEngine;

namespace Platformer
{
    public class CoreView : LevelObjectView
    {
        public TrailRenderer Trail;

        public void SetVisible(bool visible)
        {
            if (Trail) Trail.enabled = visible;
            if (Trail) Trail.Clear();
            SpriteRenderer.enabled = visible;
        }
    }
}
