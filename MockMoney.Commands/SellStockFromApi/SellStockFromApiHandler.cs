using MediatR;
using MockMoney.Abstractions.HttpClients;


namespace MockMoney.Commands.SellStockFromApi;

public sealed class SellStockHandler : IRequestHandler<SellStockApiRequest, SellStockApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public SellStockHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<SellStockApiResponse> Handle(SellStockApiRequest request, CancellationToken cancellationToken)
    {
        var token = request.Token;
        var amount = request.Amount;
        var ticket = request.Ticket;

        var isSuccessful = await _httpClient.SellStockAsync(token, amount, ticket, cancellationToken);
        return new SellStockApiResponse
        {
            IsSuccessful = isSuccessful
        };
    }
}