using System;
using UnityEngine;

namespace Platformer
{
    public sealed class PCInputFireAttack : IUserPressButtonProxy
    {
        public event Action<bool> OnButtonDown = delegate(bool b) {  };
        public event Action<bool> OnButtonUp = delegate(bool b) {  };
        public void GetButtonDown()
        {
            OnButtonDown?.Invoke(Input.GetButton(AxisManager.FIREBALL_ATTACK));
        }

        public void GetButtonUp()
        {
            OnButtonUp?.Invoke(Input.GetButtonUp(AxisManager.FIREBALL_ATTACK));
        }
    }
}
