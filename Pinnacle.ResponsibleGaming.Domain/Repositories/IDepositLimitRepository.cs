﻿using System.Threading.Tasks;
using Pinnacle.ResponsibleGaming.Domain.Models;

namespace Pinnacle.ResponsibleGaming.Domain.Repositories
{
    public interface IDepositLimitRepository
    {
        Task<DepositLimit> GetActiveByCustomerId(string customerId);
        Task Upsert(DepositLimit depositLimit);
    }
}