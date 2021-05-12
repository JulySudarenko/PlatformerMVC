using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "CharactersData", menuName = "Configs/CharactersData", order = 0)]
    internal class CharactersData : ScriptableObject
    {
        [SerializeField] private string _playerConfigPath = "PlayerConfig";
        [SerializeField] private string _redSpotCnfPath;
        [SerializeField] private string _snailCnfPath = "SnailEnemyCnf";
        [SerializeField] private string _slugCnfPath  = "SlugEnemyConfig";
        [SerializeField] private string _batEnemyCnfPath;
        [SerializeField] private string _evilBatEnemyCnfPath;

        private PlayerConfig _playerConfig;
        private PlayerConfig _redSpotCnf;
        private EnemyConfig _snailCnf;
        private EnemyConfig _slugEnemyCnf;
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

        public EnemyConfig SnailEnemyCnf
        {
            get
            {
                if (_snailCnf == null)
                {
                    _snailCnf = Load<EnemyConfig>("Characters/" + _snailCnfPath);
                }

                return _snailCnf;
            }
        }
        
        public EnemyConfig SlugEnemyCnf
        {
            get
            {
                if (_slugEnemyCnf == null)
                {
                    _slugEnemyCnf = Load<EnemyConfig>("Characters/" + _slugCnfPath);
                }

                return _slugEnemyCnf;
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
