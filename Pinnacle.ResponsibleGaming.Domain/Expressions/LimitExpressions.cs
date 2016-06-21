using System;
using System.Linq.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Expressions
{
    public static class LimitExpressions
    {
        public static Expression<Func<Limit, bool>> CurrentCustomerLimit(string customerId)
        {
            return x => x.CustomerId == customerId && x.StartDate < DateTime.Now;
        }
    }
}
