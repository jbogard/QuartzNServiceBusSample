using System;
using NServiceBus;
using NServiceBus.Installation;
using Quartz;
using QuartzNServiceBusSample.Messages;

namespace QuartzNServiceBusSample
{
    public class DoSomethingSchedule : ScheduleSetup<DoSomethingJob> 
    {
        public DoSomethingSchedule(IScheduler scheduler) : base(scheduler)
        {
        }

        protected override TriggerBuilder CreateTrigger()
        {
            return TriggerBuilder.Create().WithCalendarIntervalSchedule(b => b.WithIntervalInSeconds(5));
        }
    }

    public class DoSomethingJob : IJob
    {
        public IBus Bus { get; set; }

        public void Execute(IJobExecutionContext context)
        {
            Bus.Send(new DoSomething());
        }
    }
}