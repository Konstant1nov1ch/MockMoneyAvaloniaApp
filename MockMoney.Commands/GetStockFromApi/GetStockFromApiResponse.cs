using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetStock;

public sealed record GetStockFromApiResponse
{
    public required SimpleResultStock Stock { get; init; }
}
