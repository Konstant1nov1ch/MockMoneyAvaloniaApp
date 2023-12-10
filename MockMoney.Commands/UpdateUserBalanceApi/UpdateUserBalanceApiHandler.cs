using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.UpdateUserBalanceApi;

public sealed class UpdateUserBalanceHandler : IRequestHandler<UpdateUserBalanceApiRequest, UpdateUserBalanceApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public UpdateUserBalanceHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<UpdateUserBalanceApiResponse> Handle(UpdateUserBalanceApiRequest request, CancellationToken cancellationToken)
    {
        var token = request.Token;
        var amount = request.Amount;

        var isSuccessful = await _httpClient.UpdateUserBalanceAsync(token, amount, cancellationToken);
        return new UpdateUserBalanceApiResponse()
        {
            IsSuccessful = isSuccessful
        };
    }
}
