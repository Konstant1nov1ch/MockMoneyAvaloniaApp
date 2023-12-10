using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.GetAllMyStocksFromApi;


public sealed class GetAllMyStocksHandler : IRequestHandler<GetAllMyStocksApiRequest, GetAllMyStocksApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public GetAllMyStocksHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<GetAllMyStocksApiResponse> Handle(GetAllMyStocksApiRequest request, CancellationToken cancellationToken)
    {
        var token = request.Token;
        var stocks = await _httpClient.GetAllMyStocksAsync(token, cancellationToken);
        return new GetAllMyStocksApiResponse
        {
            Stocks = stocks.Stocks
        };
    }
}
