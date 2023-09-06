namespace DependencyInjection.Services
{
    public interface IScopedCounterService
    {
        int Increment();
        int CurrentCount { get; }
    }

    public class ScopedCounterService : IScopedCounterService
    {
        public int CurrentCount { get; private set; } = 0;
        public int Increment() => ++CurrentCount;
    }
}
