using System;
using System.Linq.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Expressions
{
    public static class LimitExpressions
    {
        public static Expression<Func<T, bool>> CurrentActiveLimit<T>(string customerId) where T: Limit
        {
            var now = DateTime.Now;
            var now2 = DateTime.Now;
            return x => x.CustomerId == customerId && now >= x.StartDate && (!x.EndDate.HasValue || now <  x.EndDate );
        }
    }
}
