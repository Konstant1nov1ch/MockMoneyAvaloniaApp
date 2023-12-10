namespace MockMoney.Commands.BuyStockFromApi;

public sealed record BuyStockApiResponse
{
    public required bool IsSuccessful { get; init; }
}