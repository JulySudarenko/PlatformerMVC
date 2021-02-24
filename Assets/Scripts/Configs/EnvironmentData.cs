using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnvironmentData", menuName = "Configs/EnvironmentData", order = 0)]
    internal class EnvironmentData : ScriptableObject
    {
        [SerializeField] private string _coinCnfPath;
        [SerializeField] private string _rocketCnfPath;
        [SerializeField] private string _backgroundCnfPath;

        private ItemConfig _coinCnf;
        private ItemConfig _rocketCnf;
        private BackGroundConfig _backgroundCnf;

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

        public BackGroundConfig BackGroundConfig
        {
            get
            {
                if (_backgroundCnf == null)
                {
                    _backgroundCnf = Extentions.Load<BackGroundConfig>(_backgroundCnfPath);
                }

                return _backgroundCnf;
            }
        }
    }
}
