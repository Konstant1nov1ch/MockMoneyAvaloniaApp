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
        var token  = await _httpClient.GetJwtTokenAsync( request.Login, request.Password, cancellationToken);

        return new LoginApiResponse
        {
            Token = token
        };
    }
}

