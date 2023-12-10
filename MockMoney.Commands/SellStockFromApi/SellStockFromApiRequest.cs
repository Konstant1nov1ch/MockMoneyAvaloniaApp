using MediatR;

namespace MockMoney.Commands.SellStockFromApi;

public sealed record SellStockApiRequest(string Token, int Amount, string Ticket) : IRequest<SellStockApiResponse>
{
}
