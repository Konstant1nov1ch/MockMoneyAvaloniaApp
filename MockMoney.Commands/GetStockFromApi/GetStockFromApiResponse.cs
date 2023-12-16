using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetStockFromApi;

public sealed record GetStockFromApiResponse
{
    public required SimpleResultStock Stock { get; init; }
}
