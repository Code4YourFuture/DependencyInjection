namespace DependencyInjection.Services
{
    public interface ISingletonCounterService
    {
        int Increment();
        int CurrentCount { get; }
    }
    public class SingletonCounterService : ISingletonCounterService
    {
        public int CurrentCount { get; private set; } = 0;
        public int Increment() => ++CurrentCount;
    }
}
