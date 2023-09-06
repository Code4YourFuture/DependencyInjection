namespace DependencyInjection.Services
{
    public interface ITransientCounterService
    {
        int Increment();
        int CurrentCount { get; }
    }
    public class TransientCounterService : ITransientCounterService
    {
        public int CurrentCount { get; private set; } = 0;
        public int Increment() => ++CurrentCount;
    }
}
