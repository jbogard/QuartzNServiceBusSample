using System.Security.Principal;
using NServiceBus;
using NServiceBus.Installation;
using Quartz;

namespace QuartzNServiceBusSample
{
    public abstract class ScheduleSetup<TJob> 
        : IWantToRunAtStartup 
        where TJob : IJob
    {
        private readonly IScheduler _scheduler;

        protected ScheduleSetup(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        protected abstract TriggerBuilder CreateTrigger();

        public void Run()
        {
            var typeOfJob = typeof(TJob);
            var jobName = typeOfJob.Name;
            var jobKey = new JobKey(jobName);

            var jobDetail = JobBuilder.Create<TJob>().WithIdentity(jobKey).Build();
            var trigger = CreateTrigger().ForJob(jobDetail).Build();

            if (_scheduler.GetJobDetail(jobKey) == null)
            {
                _scheduler.ScheduleJob(jobDetail, trigger);
            }
            else
            {
                var triggerName = typeof(TJob).Name + "-CronTrigger";

                _scheduler.RescheduleJob(new TriggerKey(triggerName), trigger);
            }
        }

        public void Stop()
        {
        }
    }
}