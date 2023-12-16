namespace MockMoney.Infrastructure.Service;

public class TokenService : ITokenService
{
    private string _token;
    public event EventHandler TokenChanged;

    protected virtual void OnTokenChanged()
    {
        TokenChanged?.Invoke(this, EventArgs.Empty);
    }

    public string Token
    {
        get => _token;
        set
        {
            _token = value;
            OnTokenChanged(); // Вызывает событие при изменении токена
        }
    }
}