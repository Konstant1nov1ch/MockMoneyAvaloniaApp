using MediatR;

namespace MockMoney.Commands.RegisterApi;

public sealed record RegisterApiRequest(string DisplayName, string Login, string Password) : IRequest<RegisterApiResponse>
{
}
