using System;
using System.Linq.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Domain.Expressions
{
    public static class LimitExpressions
    {
        public static Expression<Func<Limit, bool>> IsActive(string customerId, LimitType limitType)
        {
            var now = DateTime.Now;
            return x => x.CustomerId == customerId && x.LimitType == limitType && now >= x.StartDate && (!x.EndDate.HasValue || now < x.EndDate);
        }
        public static Expression<Func<Limit, bool>> IsActive()
        {
            var now = DateTime.Now;
            return x =>  now >= x.StartDate && (!x.EndDate.HasValue || now < x.EndDate);
        }
    }
}
