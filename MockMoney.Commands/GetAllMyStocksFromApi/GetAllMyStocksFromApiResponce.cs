using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetAllMyStocksFromApi;

public sealed record GetAllMyStocksApiResponse
{
    public required List<SimpleResultStock> Stocks { get; init; }
}
