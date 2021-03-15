

namespace Platformer
{
    public sealed class InputController : IFixedExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserPressButtonProxy _swordAttack;
        private readonly IUserPressButtonProxy _fireAttack;
        private readonly IUserPressButtonProxy _block;

        public InputController(
            (IUserInputProxy inputHorizontal, 
             IUserInputProxy inputVertical) moveInput,
            (IUserPressButtonProxy inputSwordAttack, 
             IUserPressButtonProxy inputFireAttack,
             IUserPressButtonProxy inputBlock) attackInput)
        {
            _horizontal = moveInput.inputHorizontal;
            _vertical = moveInput.inputVertical;
            _swordAttack = attackInput.inputSwordAttack;
            _fireAttack = attackInput.inputFireAttack;
            _block = attackInput.inputBlock;
        }

        public void FixedExecute(float deltatime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _swordAttack.GetButtonDown();
            _fireAttack.GetButtonDown();
            _block.GetButtonDown();
        }
    }
}
