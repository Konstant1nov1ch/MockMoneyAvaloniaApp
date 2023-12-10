using MediatR;

namespace MockMoney.Commands.CheckHealthApi;

public sealed record CheckHealthApiRequest : IRequest<CheckHealthApiResponse>
{
}
