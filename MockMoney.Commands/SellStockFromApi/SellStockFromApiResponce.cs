namespace MockMoney.Commands.SellStockFromApi;

public sealed record SellStockApiResponse
{
    public required bool IsSuccessful { get; init; }
}
