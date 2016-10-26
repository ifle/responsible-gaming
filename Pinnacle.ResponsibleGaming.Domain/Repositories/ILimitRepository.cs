using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILimitRepository
    {
        Task<Limit> GetCustomerLimitByLimitType(string customerId, LimitType limitType);
        Task AddOrUpdate(Limit limit);
    }
}