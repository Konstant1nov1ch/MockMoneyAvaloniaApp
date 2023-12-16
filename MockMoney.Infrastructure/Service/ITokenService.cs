namespace MockMoney.Infrastructure.Service
{
    public interface ITokenService
    {
        string Token { get; set; }
        event EventHandler TokenChanged;
    }
    
}