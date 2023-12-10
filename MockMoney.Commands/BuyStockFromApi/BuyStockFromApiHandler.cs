using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.BuyStockFromApi;

public sealed class BuyStockHandler : IRequestHandler<BuyStockApiRequest, BuyStockApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public BuyStockHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<BuyStockApiResponse> Handle(BuyStockApiRequest request, CancellationToken cancellationToken)
    {
        var token = request.Token;
        var amount = request.Amount;
        var ticket = request.Ticket;

        var isSuccessful = await _httpClient.BuyStockAsync(token, amount, ticket, cancellationToken);
        return new BuyStockApiResponse
        {
            IsSuccessful = isSuccessful
        };
    }
}
