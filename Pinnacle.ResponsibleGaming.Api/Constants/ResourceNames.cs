

namespace Pinnacle.ResponsibleGaming.Api.Constants
{
    public static class ResourceNames
    {
        public const string Customers = "customers"; //Customers with current limits
        public const string Users = "users"; //Users that have set limits
        public const string DepositLimit = "deposit-limit/{customerId}";
        public const string Log = "log"; //Log?{username}{customerId}
    }
}
