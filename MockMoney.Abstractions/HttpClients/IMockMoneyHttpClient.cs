using MockMoney.Model.MockMoneyApiJsonObjects;


namespace MockMoney.Abstractions.HttpClients;

public interface IMockMoneyHttpClient
{
    Task<string> GetJwtTokenAsync(string login, string password, CancellationToken cancellationToken = default);
    Task<GetStocks> GetAllStocksAsync(string token, CancellationToken cancellationToken = default);
    Task<UserInfo> GetUserInfoAsync(string token, CancellationToken cancellationToken = default);
    Task<GetStocks> GetAllMyStocksAsync(string token, CancellationToken cancellationToken = default);
    Task<bool> BuyStockAsync(string token, int amount, string ticket, CancellationToken cancellationToken = default);
    Task<bool> SellStockAsync(string token, int amount, string ticket, CancellationToken cancellationToken = default);
    Task<SimpleResultStock> GetSpecificStockAsync(string token, string id, CancellationToken cancellationToken = default);
    Task<float[]> GetPolynomialCoefficientsAsync(string token, CancellationToken cancellationToken = default);
    Task<bool> RegisterAsync(string displayName, string login, string password, CancellationToken cancellationToken = default);
    Task<bool> CheckHealthAsync(CancellationToken cancellationToken = default);
    Task<bool> UpdateUserBalanceAsync(string token, int amount, CancellationToken cancellationToken = default);
}
