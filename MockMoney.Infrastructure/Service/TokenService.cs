namespace MockMoney.Infrastructure.Service;

public class TokenService : ITokenService
{
    private string _token;

    public string Token
    {
        get => _token;
        set => _token = value;
    }
}
