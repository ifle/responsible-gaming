using Pinnacle.ResponsibleGaming.Persistence.Contexts;


namespace Pinnacle.ResponsibleGaming.Application.Contexts
{
    public class SetDepositLimitContext : Context
    {
        public SetDepositLimitContext(MainContext mainDbContext) : base(mainDbContext)
        {

        }
    }
}
