using NServiceBus;
using NServiceBus.ObjectBuilder;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace QuartzNServiceBusSample
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client
    {
    }

    public class SendOnly : IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Instance
                .SendOnly();
        }
    }

    public class QuartzConfiguration : IWantCustomInitialization
    {
        public void Init()
        {
            var configurer = Configure.Instance.Configurer;
            configurer
                .ConfigureComponent<IJobFactory>(
                    () => new QuartzJobFactory(Configure.Instance.Builder),
                    DependencyLifecycle.InstancePerUnitOfWork)
                ;
            configurer.ConfigureComponent<IScheduler>(() =>
            {
                var factoryx = new StdSchedulerFactory();
                factoryx.Initialize();

                var scheduler = factoryx.GetScheduler();
                scheduler.JobFactory = Configure.Instance.Builder.Build<IJobFactory>();
                return scheduler;

            }, DependencyLifecycle.SingleInstance);
            configurer.ConfigureComponent<DoSomethingJob>(DependencyLifecycle.InstancePerUnitOfWork);
        }
    }
}