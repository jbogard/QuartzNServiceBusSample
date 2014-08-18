using NServiceBus;
using Quartz;

namespace QuartzNServiceBusSample
{
    public class QuartzService : IWantToRunWhenBusStartsAndStops
    {
        private readonly IScheduler _scheduler;

        public QuartzService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }
        
        public void Start()
        {
            _scheduler.Start();
        }
            
        public void Stop()
        {
            _scheduler.Shutdown(true);
        }
        }
}