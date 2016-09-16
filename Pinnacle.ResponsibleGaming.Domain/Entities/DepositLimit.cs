﻿using System;
using Pinnacle.ResponsibleGaming.Domain.Messages;
using Pinnacle.ResponsibleGaming.Domain.Rules;
using Pinnacle.ResponsibleGaming.Domain._Framework.Exceptions;
using Pinnacle.ResponsibleGaming.Events;

namespace Pinnacle.ResponsibleGaming.Domain.Entities
{
    public class DepositLimit : Limit
    {
        public decimal Amount { get; set; }

        public DepositLimit()
        {
        }
        public DepositLimit(string customerId, decimal amount, int? periodInDays, DateTime? startDate, DateTime? endDate, string author)
        {
            var now = DateTime.Now;

            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = customerId,
                Amount = amount,
                PeriodInDays = periodInDays,
                StartDate = startDate ?? now,
                EndDate = endDate,
                Author = author,
                ModificationTime = now
            };

            ApplyEvent(depositLimitSet);
           
        }

        public void Modify(DepositLimit depositLimit)
        {
            // Apply business rules
            //TODO: (Cesar) Check that the new limit is different
            //TODO: (Cesar) Check that CustomerId and StartDate have not changed. These are inmutable. 
            if (!DepositLimitRules.NewLAmountMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.Amount, Amount)) { throw new ConflictException(DepositLimitMessages.LimitMustBeMoreRestrictiveThanTheCurrentOne); }
            if (!DepositLimitRules.PeriodAndAmountCannotBeChangedAtOnce(depositLimit.Amount, Amount, depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodAndLimitCannotBeChangedAtOnce); }
            if (!DepositLimitRules.NewPeriodMustBeMoreRestrictiveThanTheCurrentOne(depositLimit.PeriodInDays, PeriodInDays)) { throw new ConflictException(DepositLimitMessages.PeriodMustBeMoreRestrictiveThanTheCurrentOne); }

            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = depositLimit.CustomerId,
                Amount = depositLimit.Amount,
                PeriodInDays = depositLimit.PeriodInDays,
                StartDate = depositLimit.StartDate,
                EndDate = depositLimit.EndDate,
                Author = depositLimit.Author,
                ModificationTime = depositLimit.ModificationTime
            };

            ApplyEvent(depositLimitSet);
        }
        public void Disable(string author)
        {
            var now = DateTime.Now;
            var depositLimitSet = new DepositLimitSet
            {
                CustomerId = CustomerId,
                Amount = Amount,
                PeriodInDays = PeriodInDays,
                StartDate = StartDate,
                EndDate = now.AddDays(1),//TODO: (Cesar) Cooling-off period
                Author = author,
                ModificationTime = now
            };

            ApplyEvent(depositLimitSet);
        }

        public void ApplyEvent(DepositLimitSet depositLimitSet)
        {
            Events.Add(new Event(depositLimitSet));

            CustomerId = depositLimitSet.CustomerId;
            Amount = depositLimitSet.Amount;
            PeriodInDays = depositLimitSet.PeriodInDays;
            StartDate = depositLimitSet.StartDate;
            EndDate = depositLimitSet.EndDate;
            Author = depositLimitSet.Author;
            ModificationTime = depositLimitSet.ModificationTime;
        }
    }
}
