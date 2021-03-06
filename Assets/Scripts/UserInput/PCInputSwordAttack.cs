﻿using System;
using UnityEngine;

namespace Platformer
{
    public sealed class PCInputSwordAttack : IUserPressButtonProxy
    {
        public event Action<bool> OnButtonDown = delegate(bool b) {  };
        public event Action<bool> OnButtonUp = delegate(bool b) {  };
        public void GetButtonDown()
        {
            OnButtonDown?.Invoke(Input.GetButton(AxisManager.SWORD_ATTACK));
        }

        public void GetButtonUp()
        {
            OnButtonUp?.Invoke(Input.GetButtonUp(AxisManager.SWORD_ATTACK));
        }
    }
}
