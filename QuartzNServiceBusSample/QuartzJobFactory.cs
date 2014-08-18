using NServiceBus.ObjectBuilder;
using NServiceBus.ObjectBuilder.Common;
using Quartz;
using Quartz.Spi;

namespace QuartzNServiceBusSample
{
    public class QuartzJobFactory : IJobFactory
    {
        private readonly IBuilder _container;

        public QuartzJobFactory(IBuilder container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _container.Build(bundle.JobDetail.JobType) as IJob;
        }


        public void ReturnJob(IJob job)
        {
            return;
        }
    }
}