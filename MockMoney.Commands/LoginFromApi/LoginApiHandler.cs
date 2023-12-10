using MediatR;
using MockMoney.Abstractions.HttpClients;

namespace MockMoney.Commands.LoginFromApi;

public sealed class LoginApiHandler : IRequestHandler<LoginApiRequest, LoginApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public LoginApiHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<LoginApiResponse> Handle(LoginApiRequest request, CancellationToken cancellationToken)
    {
        var token  = await LoginAsync( request.Login, request.Password, cancellationToken);

        return new LoginApiResponse()
        {
            Token = token
        };
    }

    private async Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken)
    {
        return await _httpClient.GetJwtTokenAsync(login,  password, cancellationToken);
    }
}

