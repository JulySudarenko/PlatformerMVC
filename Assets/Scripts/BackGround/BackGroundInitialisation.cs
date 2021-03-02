namespace Platformer
{
    internal class BackGroundInitialisation
    {
        private IBackGroundFactory _factory;

        public BackGroundInitialisation(IBackGroundFactory factory)
        {
            _factory = factory;
        }

        public ParalaxBackGround GetParalaxBackGround()
        {
            return _factory.Create();
        }
    }
}
