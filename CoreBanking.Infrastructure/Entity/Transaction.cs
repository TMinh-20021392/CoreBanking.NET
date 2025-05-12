using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace CoreBanking.Infrastructure.Entity;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateUtc { get; set; }
    public TransactionType Type { get; set; } = default!;
    public Guid AccountId { get; set; }

    [JsonIgnore]
    public Account Account { get; set; } = default!;
}

public sealed class TransactionType : SmartEnum<TransactionType>
{
    public static readonly TransactionType Deposit = new(nameof(Deposit), 1);
    public static readonly TransactionType Withdraw = new(nameof(Withdraw), 2);

    private TransactionType(string name, int value) : base(name, value) { }
}
