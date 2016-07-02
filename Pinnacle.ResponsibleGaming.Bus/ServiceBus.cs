using System.ServiceProcess;
using Pinnacle.ResponsibleGaming.Persistence.Contexts;
using Pinnacle.ResponsibleGaming.Read.Updaters;

namespace Pinnacle.ResponsibleGaming.Bus
{
    public partial class ServiceBus : ServiceBase
    {
        public Bus _bus;

        public ServiceBus()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var dbContext = new MainContext();
            _bus = new Bus(new LogUpdater(dbContext));
        }

        protected override void OnStop()
        {
            _bus.Dispose();
        }
    }
}
