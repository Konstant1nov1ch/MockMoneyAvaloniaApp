using MediatR;

namespace MockMoney.Commands.UpdateUserBalanceApi;

public sealed record UpdateUserBalanceApiRequest(string Token, int Amount) : IRequest<UpdateUserBalanceApiResponse>
{
}
