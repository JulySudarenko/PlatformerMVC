using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    [CreateAssetMenu(fileName = "GameDisplay", menuName = "UI/GameDisplay", order = 0)]
    public class GameDisplayData : ScriptableObject
    {
        public GameObject GamePanel;
        //public Text HealthPoints;
        public Text GamePoints;
        public Image Hearts;
    }
}
