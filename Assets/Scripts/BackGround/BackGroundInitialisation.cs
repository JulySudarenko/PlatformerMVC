namespace Platformer
{
    internal class BackGroundInitialisation
    {
        private readonly IBackGroundFactory _factory;

        public BackGroundInitialisation(IBackGroundFactory factory)
        {
            _factory = factory;
        }

        public ParallaxBackGround GetParalaxBackGround()
        {
            return _factory.Create();
        }
    }
}
