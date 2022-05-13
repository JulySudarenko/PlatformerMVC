using System;
using UnityEngine;

namespace Platformer
{
    internal class PlayerAttack
    {
        public Action<PlayerState> OnAttackStateChange;
        private readonly IUserPressButtonProxy _swordAttackInputProxy;
        private readonly IUserPressButtonProxy _fireAttackInputProxy;
        private readonly IUserPressButtonProxy _blockInputProxy;
        private readonly FireAttack _fireAttack;
        private readonly SwordAttack _swordAttack;
        private readonly Block _block;
        private bool _isSwordAttack;
        private bool _isFireAttack;
        private bool _isBlock;

        public PlayerAttack(Transform player, PlayerConfig config,
            (IUserPressButtonProxy inputSwordAttack, IUserPressButtonProxy inputFireAttack,
                IUserPressButtonProxy inputBlock) attackInput, DamagingObjects damagingObjects)
        {
            _swordAttackInputProxy = attackInput.inputSwordAttack;
            _fireAttackInputProxy = attackInput.inputFireAttack;
            _blockInputProxy = attackInput.inputBlock;
            _swordAttackInputProxy.OnButtonDown += SwordAttackOnAxisOnChange;
            _fireAttackInputProxy.OnButtonDown += FireAttackOnAxisOnChange;
            _blockInputProxy.OnButtonDown += BlockOnAxisOn;
            _fireAttack = new FireAttack(config, player, damagingObjects);
            _swordAttack = new SwordAttack(config.SwordPrefab, damagingObjects, player);
            _block = new Block(config.ShieldPrefab, player);
        }

        private void SwordAttackOnAxisOnChange(bool value) => _isSwordAttack = value;
        private void FireAttackOnAxisOnChange(bool value) => _isFireAttack = value;
        private void BlockOnAxisOn(bool value) => _isBlock = value;

        public void FixedExecute(float deltaTime)
        {
            if (_isBlock)
            {
                OnAttackStateChange?.Invoke(PlayerState.Block);
                _block.PutUpShield();
            }
            else
            {
                _block.RemoveShield();
            }

            if (_isFireAttack)
            {
                OnAttackStateChange?.Invoke(PlayerState.FireAttack);
                _fireAttack.AttackFire();
            }

            if (_isSwordAttack)
            {
                OnAttackStateChange?.Invoke(PlayerState.SwordAttack);
                _swordAttack.StrikeSword();
            }
            else
            {
                _swordAttack.RemoveSword();
            }
        }

        public void Cleanup()
        {
            _swordAttackInputProxy.OnButtonDown -= SwordAttackOnAxisOnChange;
            _fireAttackInputProxy.OnButtonDown -= FireAttackOnAxisOnChange;
            _blockInputProxy.OnButtonDown -= BlockOnAxisOn;
            _fireAttack.Cleanup();
        }
    }
}
