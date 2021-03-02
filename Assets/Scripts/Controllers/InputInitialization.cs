namespace Platformer
{
    internal sealed class InputInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserPressButtonProxy _pcInputSwordAttack;
        private IUserPressButtonProxy _pcInputFireAttack;
        private IUserPressButtonProxy _pcInputBlock;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputSwordAttack = new PCInputSwordAttack();
            _pcInputFireAttack = new PCInputFireAttack();
            _pcInputBlock = new PCInputBlock();
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetMoveInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical)
                result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public (IUserPressButtonProxy inputSwordAttack, IUserPressButtonProxy inputFireAttack,
                IUserPressButtonProxy inputBlock) GetAttackInput()
        {
            (IUserPressButtonProxy inputSwordAttack,
             IUserPressButtonProxy inputFireAttack,
             IUserPressButtonProxy inputBlock)
                result = (_pcInputSwordAttack, _pcInputFireAttack, _pcInputBlock);
            return result;
        }
    }
}
