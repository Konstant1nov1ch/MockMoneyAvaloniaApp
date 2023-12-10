using MediatR;

namespace MockMoney.Commands.GetAllMyStocksFromApi;

public sealed record GetAllMyStocksApiRequest(string Token) : IRequest<GetAllMyStocksApiResponse>
{
}
