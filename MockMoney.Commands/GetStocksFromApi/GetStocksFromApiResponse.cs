using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetStocksFromApi;

public sealed record GetStocksFromApiResponse
{
    public required List<SimpleResultStock> Stocks { get; init; } 
}
