using log4net;
using NServiceBus;
using QuartzNServiceBusSample.Messages;

namespace QuartzNServiceBusSample.Host
{
    public class DoSomethingHandler : IHandleMessages<DoSomething>
    {
        private static ILog log =LogManager.GetLogger("tes");
        public void Handle(DoSomething message)
        {
            log.Info("Doing Something.");
        }
    }
}