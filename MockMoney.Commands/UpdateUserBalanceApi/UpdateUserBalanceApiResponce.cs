namespace MockMoney.Commands.UpdateUserBalanceApi;

public sealed record UpdateUserBalanceApiResponse
{
    public required bool IsSuccessful { get; init; }
}
