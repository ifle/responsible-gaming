

using Orleans;

namespace Pinnacle.ResponsibleGaming.Api
{
    public static class OrleansConfig
    {
        public static void InitializeGrainClient()
        {
            var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);
            GrainClient.Initialize(config);
        }
    }
}