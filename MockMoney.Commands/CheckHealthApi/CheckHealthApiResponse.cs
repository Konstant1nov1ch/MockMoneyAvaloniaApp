namespace MockMoney.Commands.CheckHealthApi;

public sealed record CheckHealthApiResponse
{
    public required bool IsHealthy { get; init; }
}
