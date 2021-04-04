using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public interface IMenuDisplay
    {
        GameObject CreateMenuDisplay();
        Button CreateRestartButton();
        Button CreatePlayButton();
        Button CreateQuitButton();
    }
}
