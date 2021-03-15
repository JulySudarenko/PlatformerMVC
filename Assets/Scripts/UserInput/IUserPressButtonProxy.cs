using System;

namespace Platformer
{
    public interface IUserPressButtonProxy
    {
        event Action<bool> OnButtonDown;
        event Action<bool> OnButtonUp;
        void GetButtonDown();
        void GetButtonUp();
    }
}
