using Pinnacle.ResponsibleGaming.Api.Constants;
using WebApi.Hal;


namespace Pinnacle.ResponsibleGaming.Api.Links
{
    public static class DepositLimitLinks
    {
        public static Link Get { get { return new Link("self", "~/" + ResourceNames.DepositLimit); } }
    }
}