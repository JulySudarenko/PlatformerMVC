using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public interface IGameDisplay
    {
        GameObject CreateGamePanel();
        //Text CreateHealthPointsText();
        Image CreateHealthPointsText();
        Text CreateGamePointsText();
    }
}
