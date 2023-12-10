using MediatR;

namespace MockMoney.Commands.LoginFromApi;

public sealed record LoginApiRequest(string Login, string Password) : IRequest<LoginApiResponse>
{
}
