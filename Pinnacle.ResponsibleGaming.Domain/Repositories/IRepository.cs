using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;


namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public  interface IRepository<T> where T:Limit
    {
        void AddOrUpdate(T t);
    }
}
