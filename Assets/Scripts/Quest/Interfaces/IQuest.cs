using System;
namespace PlatformerMVC
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; } 
        void Reset();
    }
}
