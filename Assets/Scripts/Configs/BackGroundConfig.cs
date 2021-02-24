using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "BackGroundConfig", menuName = "Configs/BackGroundConfig", order = 0)]
    public class BackGroundConfig : ScriptableObject
    {
        public Transform SkyTexture;
        public Transform MountainsBackGroundSlow;
        public Transform MountainsBackGroundFast;
        public Transform MountainsForeGround;
        public Transform SkyBackGround;
        public Transform SkyForeGround;

        [SerializeField] private float _slowSpeedBackGround;
        [SerializeField] private float _fastSpeedBackGround;
        [SerializeField] private float _speedForeGround;

        public float SlowSpeedBackGround => _slowSpeedBackGround;

        public float FastSpeedBackGround => _fastSpeedBackGround;

        public float SpeedForeGround => _speedForeGround;
    }
}
