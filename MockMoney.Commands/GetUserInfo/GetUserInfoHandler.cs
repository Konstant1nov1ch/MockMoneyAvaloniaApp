using MediatR;
using MockMoney.Abstractions.HttpClients;


namespace MockMoney.Commands.GetUserInfo;

public sealed class GetUserInfoHandler : IRequestHandler<GetUserInfoRequest, GetUserInfoResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public GetUserInfoHandler(IMockMoneyHttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<GetUserInfoResponse> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
    {
        // Retrieve user info using token from the request
        var token = request.Token;
        var userInfo = await _httpClient.GetUserInfoAsync(token, cancellationToken);

        // Create and return the response object
        return new GetUserInfoResponse
        {
            UserInfo = userInfo
        };
    }
}