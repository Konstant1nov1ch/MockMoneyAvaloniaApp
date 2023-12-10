namespace MockMoney.Commands.LoginFromApi;

public sealed record LoginApiResponse
{
    public required string Token { get; init; }
}
