using Actio.Common.Events;
using Actio.Common.Services;

namespace Actio.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreatedEvent>()
                .Build()
                .Run();
        }
    }
}
