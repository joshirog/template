using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Infrastructure.Persistences.Seeders
{
    public class CustomerSeeder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var date = new DateTime(2012, 6, 15);
            
            builder.HasData(new List<Customer>
            {
                #region seed

                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer One",
                    CreatedAt = date
                }
                
                #endregion
            });
        }
    }
}