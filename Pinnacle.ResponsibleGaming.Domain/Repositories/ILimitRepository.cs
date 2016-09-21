using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface ILimitRepository
    {
        Task<Limit> Get(string customerId, LimitType limitType);
        void AddOrUpdate(Limit limit);
    }
}