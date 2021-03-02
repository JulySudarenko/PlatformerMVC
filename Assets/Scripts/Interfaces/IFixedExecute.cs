namespace Platformer
{
    public interface IFixedExecute : IController
    {
        void FixedExecute(float deltaTime);
    }
}
