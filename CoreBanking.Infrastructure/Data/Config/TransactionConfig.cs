using CoreBanking.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreBanking.Infrastructure.Data.Config;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(nameof(Transaction));

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(t => t.DateUtc)
               .IsRequired();

        // SmartEnum -> int value converter
        var converter = new ValueConverter<TransactionType, int>(
            v => v.Value,
            v => TransactionType.FromValue(v)
        );

        builder.Property(t => t.Type)
               .HasConversion(converter)
               .HasColumnName("TransactionType")
               .IsRequired();

        builder.HasOne(t => t.Account)
               .WithMany(a => a.Transactions)
               .HasForeignKey(t => t.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
