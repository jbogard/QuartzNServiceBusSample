using NServiceBus;
using Quartz;

namespace QuartzNServiceBusSample
{
    public abstract class ScheduleSetup<TJob> : IWantToRunAtStartup
    {
        private readonly IScheduler _scheduler;

        protected ScheduleSetup(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        protected abstract Trigger CreateTrigger();

        protected static string TriggerName
        {
            get { return typeof(TJob).Name + "-CronTrigger"; }
        }

        public void Run()
        {
            var typeOfJob = typeof(TJob);
            var jobName = typeOfJob.Name;

            var trigger = CreateTrigger();
            trigger.JobName = jobName;

            if (_scheduler.GetJobDetail(jobName, "DEFAULT") == null)
            {

                // For testing purposes: 
                //var trigger = TriggerUtils.MakeMinutelyTrigger(5);
                //trigger.Name = TriggerName;
                //trigger.StartTimeUtc = DateTimeOffset.UtcNow.AddSeconds(30).DateTime; // give NSB time to start

                var jobDetail = new JobDetail(jobName, typeOfJob);

                _scheduler.ScheduleJob(jobDetail, trigger);
            }
            else
            {
                _scheduler.RescheduleJob(TriggerName, "DEFAULT", trigger);
            }
        }

        public void Stop()
        {
        }
    }
}