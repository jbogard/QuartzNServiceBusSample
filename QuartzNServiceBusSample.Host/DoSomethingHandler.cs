using NServiceBus;
using QuartzNServiceBusSample.Messages;
using log4net;

namespace QuartzNServiceBusSample.Host
{
    public class DoSomethingHandler : IHandleMessages<DoSomething>
    {
        public void Handle(DoSomething message)
        {
            LogManager.GetLogger(this.GetType()).Info("Doing something");
        }
    }
}