using CoreBanking.API.Models;

namespace CoreBanking.API.Apis;

public static class CoreBankingApi
{
    public static IEndpointRouteBuilder MapCoreBankingApi(this IEndpointRouteBuilder builder)
    {
        var vApi = builder.NewVersionedApi("CoreBanking");
        var v1 = vApi.MapGroup("api/v{version:apiVersion}/corebanking").HasApiVersion(1, 0);

        v1.MapGet("/customers", GetCustomers);
        v1.MapGet("/customers/{id:guid}", GetCustomerById);
        v1.MapPost("/customers", CreateCustomer);

        v1.MapGet("/accounts", GetAccounts);
        v1.MapGet("/accounts/{id}", GetAccountById);
        v1.MapPost("/accounts", CreateAccount);
        v1.MapPut("/accounts/{id:guid}/deposit", Deposit);
        v1.MapPut("/accounts/{id:guid}/withdraw", Withdraw);
        v1.MapPut("/accounts/{id:guid}/transfer", Transfer);
        return builder;
    }

    private static async Task Transfer(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task Withdraw(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task Deposit(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task CreateAccount(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetAccountById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetAccounts(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task CreateCustomer(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetCustomerById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetCustomers([AsParameters] PaginationRequest paginationRequest)
    {
        throw new NotImplementedException();
    }
}

public class DepositionRequest
{
    public decimal Amount { get; set; }
}

public class WithdrawalRequest
{
    public decimal Amount { get; set; }
}

public class TransferRequest
{
    public string DestinationAccountNumber { get; set; } = default!;
    public decimal Amount { get; set; }
}
