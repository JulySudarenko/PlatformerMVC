using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig", order = 0)]  
    public class ItemConfig : ScriptableObject
    {
        public GameObject ItemPrefab;
    }
}
