using MediatR;
using MockMoney.Commands.GetStock;

namespace MockMoney.Commands.GetStockFromApi;

public record GetStockFromApiRequest(string Token, string Ticket) : IRequest<GetStockFromApiResponse>
{
}
