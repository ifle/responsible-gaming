﻿using System;
using System.Data.Entity.Migrations;
using Pinnacle.ResponsibleGaming.Infrastructure.Contexts;
using Pinnacle.ResponsibleGaming.Domain.Entities;
using Pinnacle.ResponsibleGaming.Events;
using Pinnacle.ResponsibleGaming.Infrastructure.Repositories;

namespace Pinnacle.ResponsibleGaming.Subscriber
{
    public static class Handler
    {
        public static void Handle(LimitSet limitSet)
        {
            using (var context = new MainContext())
            {
                var limitRepository = new LimitRepository(context);
                var @event = limitSet;
                var limit = limitRepository.Get(@event.CustomerId, (Domain.Entities.LimitType)@event.LimitType).Result;
                if (limit == null) limit = new Limit();
                limit.ApplyEvent(@event);
                context.Limits.AddOrUpdate(limit);
                context.SaveChanges();
                Console.WriteLine("Event processed!");
            }
        }
    }
}
