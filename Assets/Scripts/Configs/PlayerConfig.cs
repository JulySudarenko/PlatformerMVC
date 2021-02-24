using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public Transform PlayerPrefab;

    }
}
