using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.CheckHealthApi;

public sealed class CheckHealthHandler : IRequestHandler<CheckHealthApiRequest, CheckHealthApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public CheckHealthHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<CheckHealthApiResponse> Handle(CheckHealthApiRequest request, CancellationToken cancellationToken)
    {
        var resp = await _httpClient.CheckHealthAsync(cancellationToken);

        return new CheckHealthApiResponse
        {
            IsHealthy = resp
        };
    }
}
