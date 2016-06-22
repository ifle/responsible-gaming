using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public  interface ILimitRepository<T> where T:Limit
    {
        Task<T> GetCurrentActiveCustomerLimit(string customerId);
        void AddOrUpdate(T t);
    }
}
