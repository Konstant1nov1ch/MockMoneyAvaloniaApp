using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.GetStocksFromApi;

public sealed class GetStocksFromApiHandler : IRequestHandler<GetStocksFromApiRequest, GetStocksFromApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public GetStocksFromApiHandler(IMockMoneyHttpClient httpClient) => 
        _httpClient = httpClient;

    public async Task<GetStocksFromApiResponse> Handle(GetStocksFromApiRequest request, CancellationToken cancellationToken)
    {
        // Use token from request
        var token = request.Token;
        var stocks = await _httpClient.GetAllStocksAsync(token, cancellationToken);
        return new GetStocksFromApiResponse
        {
            Stocks = stocks.Stocks // Access nested list directly
        };
    }
    
}