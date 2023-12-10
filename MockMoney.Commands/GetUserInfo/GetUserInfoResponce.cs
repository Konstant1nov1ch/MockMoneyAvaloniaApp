    
using MockMoney.Model.MockMoneyApiJsonObjects;

namespace MockMoney.Commands.GetUserInfo;

public sealed record GetUserInfoResponse
{
    public required UserInfo UserInfo { get; init; }
}

