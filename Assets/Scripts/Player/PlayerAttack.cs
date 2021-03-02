using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerAttack : IFixedExecute, ICleanup
    {
        public Action<PlayerState> OnAttackStateChange;
        private Transform _player;
        private PlayerConfig _playerConfig;
        private IUserPressButtonProxy _swordAttackInputProxy;
        private IUserPressButtonProxy _fireAttackInputProxy;
        private IUserPressButtonProxy _blockInputProxy;
        private bool _swordAttack;
        private bool _fireAttack;
        private bool _block;

        public PlayerAttack(Transform player, PlayerConfig config,
            (IUserPressButtonProxy inputSwordAttack, IUserPressButtonProxy inputFireAttack,
                IUserPressButtonProxy inputBlock) attackInput)
        {
            _player = player;
            _playerConfig = config;
            _swordAttackInputProxy = attackInput.inputSwordAttack;
            _fireAttackInputProxy = attackInput.inputFireAttack;
            _blockInputProxy = attackInput.inputBlock;
            _swordAttackInputProxy.OnButtonDown += SwordAttackOnAxisOnChange;
            _fireAttackInputProxy.OnButtonDown += FireAttackOnAxisOnChange;
            _blockInputProxy.OnButtonDown += BlockOnAxisOn;
        }

        private void SwordAttackOnAxisOnChange(bool value) => _swordAttack = value;
        private void FireAttackOnAxisOnChange(bool value) => _fireAttack = value;
        private void BlockOnAxisOn(bool value) => _block = value;

        public void FixedExecute(float deltaTime)
        {
            if (_block)
            {
                Debug.Log("Block is work!");
                OnAttackStateChange?.Invoke(PlayerState.Block);
            }

            if (_fireAttack)
            {
                OnAttackStateChange?.Invoke(PlayerState.FireAttack);
                Debug.Log("Fire attack is work!");
            }

            if (_swordAttack)
            {
                OnAttackStateChange?.Invoke(PlayerState.SwordAttack);
                Debug.Log("Sword attack is work!");
            }
        }

        public void Cleanup()
        {
            _swordAttackInputProxy.OnButtonDown -= SwordAttackOnAxisOnChange;
            _fireAttackInputProxy.OnButtonDown -= FireAttackOnAxisOnChange;
            _blockInputProxy.OnButtonDown -= BlockOnAxisOn;
        }
    }
}
