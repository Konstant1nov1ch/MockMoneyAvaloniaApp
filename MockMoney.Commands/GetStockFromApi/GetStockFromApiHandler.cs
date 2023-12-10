using Avalonia.Themes.Simple;
using MediatR;
using MockMoney.Abstractions.HttpClients;
using MockMoney.Commands.GetStock;
using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetStockFromApi;

public sealed class GetStockFromApiHandler : IRequestHandler<GetStockFromApiRequest, GetStockFromApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public GetStockFromApiHandler(IMockMoneyHttpClient httpClient) => 
        _httpClient = httpClient;

    public async Task<GetStockFromApiResponse> Handle(GetStockFromApiRequest request, CancellationToken cancellationToken)
    {
        // Use request parameters directly
        var token = request.Token;
        var ticket = request.Ticket;
        var stock = await _httpClient.GetSpecificStockAsync(token, ticket, cancellationToken);

        // Simplify response object creation
        return new GetStockFromApiResponse
        {
            Stock = stock
        };
    }
}