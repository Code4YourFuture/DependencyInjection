using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class CounterController : Controller
    {
        private readonly ITransientCounterService _transientCounter;
        private readonly IScopedCounterService _scopedCounter;
        private readonly ISingletonCounterService _singletonCounter;

        public CounterController(
            ITransientCounterService transientCounter,
            IScopedCounterService scopedCounter,
            ISingletonCounterService singletonCounter)
        {
            _transientCounter = transientCounter;
            _scopedCounter = scopedCounter;
            _singletonCounter = singletonCounter;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transientCounter.CurrentCount;
            ViewBag.Scoped = _scopedCounter.CurrentCount;
            ViewBag.Singleton = _singletonCounter.CurrentCount;

            return View();
        }

        [HttpPost]
        public IActionResult Increment()
        {
            ViewBag.TransientCount = _transientCounter.CurrentCount;
            ViewBag.ScopedCount = _scopedCounter.CurrentCount;
            ViewBag.SingletonCount = _singletonCounter.CurrentCount;

            _transientCounter.Increment();
            _scopedCounter.Increment();
            _singletonCounter.Increment();

            ViewBag.TransientCount = _transientCounter.CurrentCount;
            ViewBag.ScopedCount = _scopedCounter.CurrentCount;
            ViewBag.SingletonCount = _singletonCounter.CurrentCount;

            return View("Index"); 
        }
    }
}
