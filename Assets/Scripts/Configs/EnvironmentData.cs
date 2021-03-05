using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnvironmentData", menuName = "Configs/EnvironmentData", order = 0)]
    internal class EnvironmentData : ScriptableObject
    {
        [SerializeField] private string _coinCnfPath;
        [SerializeField] private string _rocketCnfPath;
        [SerializeField] private string _backgroundCnfPath;
        [SerializeField] private string _cannonCnfPath;

        private ItemConfig _coinCnf;
        private ItemConfig _rocketCnf;
        private BackGroundConfig[] _backgroundCnf;
        private CannonConfig _cannonConfig;

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

        public ItemConfig RocketCnf
        {
            get
            {
                if (_rocketCnf == null)
                {
                    _rocketCnf = Extentions.Load<ItemConfig>("Items/" + _rocketCnfPath);
                }

                return _rocketCnf;
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
