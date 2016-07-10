using System;
using System.Linq.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Expressions
{
    public static class LimitExpressions
    {
        public static Expression<Func<T, bool>> IsActiveLimit<T>(string customerId) where T : Limit
        {
            var now = DateTime.Now;
            return x => x.CustomerId == customerId && now >= x.StartDate && (!x.EndDate.HasValue || now < x.EndDate);
        }
        public static Expression<Func<T, bool>> IsActiveLimit<T>() where T : Limit
        {
            var now = DateTime.Now;
            return x =>  now >= x.StartDate && (!x.EndDate.HasValue || now < x.EndDate);
        }
    }
}
