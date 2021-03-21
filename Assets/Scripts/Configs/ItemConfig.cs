using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Configs/ItemConfig", order = 0)]  
    public class ItemConfig : ScriptableObject
    {
        public GameObject ItemPrefab;
        [SerializeField] private string _itemAnimeCnfPath = "CoinConfig";
        [SerializeField] private float _itemAnimationSpeed = 10.0f;
        [SerializeField] private int _itemPoolSize = 20;
        [SerializeField] private int _itemCount;
        private SpriteAnimatorConfig _itemAnimatorCnf;

        public float ItemAnimationSpeed => _itemAnimationSpeed;
        public int ItemPoolSize => _itemPoolSize;
        public int ItemCount => _itemCount;

        public SpriteAnimatorConfig ItemAnimatorCnf
        {
            get
            {
                if (_itemAnimatorCnf == null)
                {
                    _itemAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _itemAnimeCnfPath);
                }
        
                return _itemAnimatorCnf;
            }
        }
    }
}
