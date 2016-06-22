using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public  interface ILimitRepository<T>: IRepository<T> where T:Limit
    {
        Task<Limit> GetCurrentActiveCustomerLimit(string customerId);
    }
}
