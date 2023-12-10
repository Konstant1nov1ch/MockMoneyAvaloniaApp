using MediatR;

namespace MockMoney.Commands.GetStocksFromApi;

public record GetStocksFromApiRequest(string Token) : IRequest<GetStocksFromApiResponse>
{
}
