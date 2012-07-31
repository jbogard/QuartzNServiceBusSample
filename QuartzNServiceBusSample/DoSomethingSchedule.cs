using System;
using NServiceBus;
using Quartz;
using QuartzNServiceBusSample.Messages;

namespace QuartzNServiceBusSample
{
    public class DoSomethingSchedule : ScheduleSetup<DoSomethingJob>
    {
        public DoSomethingSchedule(IScheduler scheduler) : base(scheduler)
        {
        }

        protected override Trigger CreateTrigger()
        {
            return TriggerUtils.MakeSecondlyTrigger(TriggerName, 5, Int32.MaxValue);
        }
    }

    public class DoSomethingJob : IJob
    {
        public IBus Bus { get; set; }

        public void Execute(JobExecutionContext context)
        {
            Bus.Send(new DoSomething());
        }
    }
}