using MediatR;

namespace MockMoney.Commands.GetUserInfo;

public sealed record GetUserInfoRequest(string Token) : IRequest<GetUserInfoResponse>
{
}