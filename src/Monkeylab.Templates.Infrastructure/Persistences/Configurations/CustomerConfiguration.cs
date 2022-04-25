using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monkeylab.Templates.Domain.Entities;

namespace Monkeylab.Templates.Infrastructure.Persistences.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasMaxLength(36)
                .IsRequired();
            
            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}