﻿using System.Data.Entity.ModelConfiguration;
using Pinnacle.ResponsibleGaming.Domain.Entities;

namespace Pinnacle.ResponsibleGaming.Persistence.Configurations
{
    public class DepositLimitConfiguration : EntityTypeConfiguration<DepositLimit>
    {
        public DepositLimitConfiguration()
        {
            //Map
            Map(x =>
                {
                    x.ToTable("Limit");
                    x.Requires("LimitTypeId").HasValue((int)LimitType.DepositLimit);
                });

            //Key
            HasKey(x => x.LimitId);

            //Properties
            Property(t => t.Amount)
                .HasColumnName("Limit")
                .HasColumnType("decimal")
                .IsRequired();
        }
    }
}