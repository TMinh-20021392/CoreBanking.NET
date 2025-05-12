using CoreBanking.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreBanking.Infrastructure.Data.Config;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Address)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(c => c.Accounts)
               .WithOne(a => a.Customer)
               .HasForeignKey(a => a.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
