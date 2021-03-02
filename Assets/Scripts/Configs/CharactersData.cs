using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "CharactersData", menuName = "Configs/CharactersData", order = 0)]
    internal class CharactersData : ScriptableObject
    {
        [SerializeField] private string _playerConfigPath = "PlayerConfig";
        [SerializeField] private string _redSpotCnfPath;
        [SerializeField] private string _snailCnfPath;
        [SerializeField] private string _batEnemyCnfPath;
        [SerializeField] private string _evilBatEnemyCnfPath;

        private PlayerConfig _playerConfig;
        private PlayerConfig _redSpotCnf;
        private PlayerConfig _snailCnf;
        private EnemyConfig _batEnemyCnf;
        private EnemyConfig _evilBatEnemyCnf;

        public PlayerConfig PlayerConfig
        {
            get
            {
                if (_playerConfig == null)
                {
                    _playerConfig = Load<PlayerConfig>("Characters/" + _playerConfigPath);
                }

                return _playerConfig;
            }
        }
        
        public PlayerConfig RedSpotCnf
        {
            get
            {
                if (_redSpotCnf == null)
                {
                    _redSpotCnf = Load<PlayerConfig>("Characters/" + _redSpotCnfPath);
                }

                return _redSpotCnf;
            }
        }

        public PlayerConfig SnailCnf
        {
            get
            {
                if (_snailCnf == null)
                {
                    _snailCnf = Load<PlayerConfig>("Characters/" + _snailCnfPath);
                }

                return _snailCnf;
            }
        }

        public EnemyConfig BatEnemyCnf
        {
            get
            {
                if (_batEnemyCnf == null)
                {
                    _batEnemyCnf = Load<EnemyConfig>("Characters/" + _batEnemyCnfPath);
                }

                return _batEnemyCnf;
            }
        }

        public EnemyConfig EvilBatEnemyCnf
        {
            get
            {
                if (_evilBatEnemyCnf == null)
                {
                    _evilBatEnemyCnf = Load<EnemyConfig>("Characters/" + _evilBatEnemyCnfPath);
                }

                return _evilBatEnemyCnf;
            }
        }
    }
}
