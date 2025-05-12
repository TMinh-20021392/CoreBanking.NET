using CoreBanking.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreBanking.Infrastructure.Data.Config;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Number)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(a => a.Balance)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.HasMany(a => a.Transactions)
               .WithOne(t => t.Account)
               .HasForeignKey(t => t.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
