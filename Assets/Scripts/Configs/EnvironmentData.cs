using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnvironmentData", menuName = "Configs/EnvironmentData", order = 0)]
    internal class EnvironmentData : ScriptableObject
    {
        [SerializeField] private string _backgroundCnfPath;
        [SerializeField] private string _levelConfigPath;
        [SerializeField] private string _cannonCnfPath;
        [SerializeField] private string _coinCnfPath;

        private BackGroundConfig[] _backgroundCnf;
        private CannonConfig _cannonConfig;
        private LevelConfig _levelConfig;
        private ItemConfig _coinCnf;

        public ItemConfig CoinCnf
        {
            get
            {
                if (_coinCnf == null)
                {
                    _coinCnf = Extentions.Load<ItemConfig>("Items/" + _coinCnfPath);
                }

                return _coinCnf;
            }
        }
        
        public LevelConfig LevelConfig
        {
            get
            {
                if (_levelConfig == null)
                {
                    _levelConfig = Extentions.Load<LevelConfig>(_levelConfigPath);
                }

                return _levelConfig;
            }
        }

        public CannonConfig CannonConfig
        {
            get
            {
                if (_cannonConfig == null)
                {
                    _cannonConfig = Extentions.Load<CannonConfig>("Items/" + _cannonCnfPath);
                }

                return _cannonConfig;
            }
        }

        public BackGroundConfig[] BackGroundConfig
        {
            get
            {
                _backgroundCnf = Extentions.LoadAll<BackGroundConfig>(_backgroundCnfPath);
                return _backgroundCnf;
            }
        }
    }
}
