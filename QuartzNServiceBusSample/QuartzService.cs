using NServiceBus;
using Quartz;

namespace QuartzNServiceBusSample
{
    public class QuartzService : IWantToRunAtStartup
    {
        private readonly IScheduler _scheduler;

        public QuartzService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Run()
        {
            _scheduler.Start();
        }

        public void Stop()
        {
            _scheduler.Shutdown(true);
        }
    }
}