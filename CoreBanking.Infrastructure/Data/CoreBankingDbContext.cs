using CoreBanking.Infrastructure.Data.Config;
using CoreBanking.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreBanking.Infrastructure.Data;
public class CoreBankingDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<Transaction> Transactions { get; set; } = default!;

    public CoreBankingDbContext() { }
    public CoreBankingDbContext(DbContextOptions<CoreBankingDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AccountConfig).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(CustomerConfig).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(TransactionConfig).Assembly);
        base.OnModelCreating(builder);
    }
}