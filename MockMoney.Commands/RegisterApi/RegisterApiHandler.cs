using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.RegisterApi;

public sealed class RegisterHandler : IRequestHandler<RegisterApiRequest, RegisterApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public RegisterHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<RegisterApiResponse> Handle(RegisterApiRequest request, CancellationToken cancellationToken)
    {
        var isSuccessful = await RegisterUserAsync(request.DisplayName, request.Login, request.Password, cancellationToken);

        return new RegisterApiResponse
        {
            IsSuccessful = isSuccessful
        };
    }

    private async Task<bool> RegisterUserAsync(string displayName, string login, string password, CancellationToken cancellationToken)
    {
        return await _httpClient.RegisterAsync(displayName, login, password, cancellationToken);
    }
}

