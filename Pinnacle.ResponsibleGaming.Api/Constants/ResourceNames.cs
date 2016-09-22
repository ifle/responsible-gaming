

namespace Pinnacle.ResponsibleGaming.Api.Constants
{
    public static class ResourceNames
    {
        public const string Customers = "customers"; //Customers with current limits   http://responsible-gaming.pinnacle.com/customer
        public const string Users = "users"; //Users that have set limits              http://responsible-gaming.pinnacle.com/users
        public const string DepositLimit = "deposit-limit/{customerId}";//             http://responsible-gaming.pinnacle.com/deposit-limit/testuser
        public const string Log = "log"; //Log?{username}{customerId}                  http://responsible-gaming.pinnacle.com/log?customerId=testuser
    }
}
