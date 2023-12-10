namespace MockMoney.Commands.RegisterApi;

public sealed record RegisterApiResponse
{
    public required bool IsSuccessful { get; init; }
}
