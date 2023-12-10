using MediatR;

namespace MockMoney.Commands.BuyStockFromApi;

public sealed record BuyStockApiRequest(string Token, int Amount, string Ticket) : IRequest<BuyStockApiResponse>
{}
