using System;
using System.Linq.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.ModelExpressions
{
    public static class LimitExpressions
    {
        public static Expression<Func<Limit, bool>> CurrentActiveCustomerLimit(string customerId)
        {
            return x => x.CustomerId == customerId && x.StartDate < DateTime.Now;
        }
    }
}
