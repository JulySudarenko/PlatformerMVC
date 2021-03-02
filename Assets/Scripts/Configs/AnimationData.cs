using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Configs/AnimationData", order = 0)]
    internal class AnimationData : ScriptableObject
    {
        [SerializeField] private string _redSpotAnimeCnfPath;
        [SerializeField] private string _snailAnimeCnfPath;
        [SerializeField] private string _batEnemyAnimeCnfPath;
        [SerializeField] private string _evilBatEnemyAnimeCnfPath;
        [SerializeField] private string _coinAnimeCnfPath;
        [SerializeField] private string _rocketAnimeCnfPath;

        private SpriteAnimatorConfig _redSpotAnimatorCnf;
        private SpriteAnimatorConfig _snailAnimatorCnf;
        private SpriteAnimatorConfig _batEnemyAnimatorCnf;
        private SpriteAnimatorConfig _evilBatEnemyAnimatorCnf;
        private SpriteAnimatorConfig _coinAnimatorCnf;
        private SpriteAnimatorConfig _rocketAnimatorCnf;
        
        public SpriteAnimatorConfig RedSpotAnimatorCnf
        {
            get
            {
                if (_redSpotAnimatorCnf == null)
                {
                    _redSpotAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _redSpotAnimeCnfPath);
                }

                return _redSpotAnimatorCnf;
            }
        }

        public SpriteAnimatorConfig SnailAnimatorCnf
        {
            get
            {
                if (_snailAnimatorCnf == null)
                {
                    _snailAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _snailAnimeCnfPath);
                }

                return _snailAnimatorCnf;
            }
        }

        public SpriteAnimatorConfig BatEnemyAnimatorCnf
        {
            get
            {
                if (_evilBatEnemyAnimatorCnf == null)
                {
                    _evilBatEnemyAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _batEnemyAnimeCnfPath);
                }

                return _evilBatEnemyAnimatorCnf;
            }
        }
        
        public SpriteAnimatorConfig EvilBatEnemyAnimatorCnf
        {
            get
            {
                if (_batEnemyAnimatorCnf == null)
                {
                    _batEnemyAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _evilBatEnemyAnimeCnfPath);
                }

                return _batEnemyAnimatorCnf;
            }
        }
        
        public SpriteAnimatorConfig CoinAnimatorCnf
        {
            get
            {
                if (_coinAnimatorCnf == null)
                {
                    _coinAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _coinAnimeCnfPath);
                }

                return _coinAnimatorCnf;
            }
        }
        
        public SpriteAnimatorConfig RocketAnimatorCnf
        {
            get
            {
                if (_rocketAnimatorCnf == null)
                {
                    _rocketAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _rocketAnimeCnfPath);
                }

                return _rocketAnimatorCnf;
            }
        }
    }
}
