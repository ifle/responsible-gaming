﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Expressions;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Domain._Common.Exceptions;

namespace Pinnacle.ResponsibleGaming.Domain.Queries
{
    public abstract class LimitQuery<T> where T : Limit
    {
        private readonly DbContext _dbContext;

        public LimitQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetActiveLimitByCustomerId(string customerId)
        {
            return await _dbContext.Set<Limit>().OfType<T>().FirstOrDefaultAsync(LimitExpressions.IsActiveLimit<T>(customerId));
        }
    }
}
