using System.Net.Http.Json;
using MockMoney.Commands;
using MockMoney.Model.MockMoneyApiJsonObjects;
using MockMoney.Abstractions.HttpClients;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MockMoney.Infrastructure.HttpClients
{
    public sealed class MockMoneyHttpClient : IMockMoneyHttpClient
    {
        private const string BaseUrl = "https://casaos.kkpin.online/";
        private readonly HttpClient _httpClient;

        public MockMoneyHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<String> GetJwtTokenAsync(string login, string password,
            CancellationToken cancellationToken = default)
        {
            string url = "/api/v1/internal/login";
            
             var requestBody = new { login, password };
            //
            // using var response = await _httpClient.PostAsJsonAsync(url, requestBody, cancellationToken);
            // response.EnsureSuccessStatusCode(); // Ensure successful response before reading
            //
            // return await response.Content.ReadAsStringAsync(cancellationToken);
        

            var response = await _httpClient.PostAsJsonAsync(url, requestBody, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var tokenResponse = JsonSerializer.Deserialize<GetTokenFromApi>(content)
                               ?? throw new Exception("Не удалось десериализовать данные о токене из API.");

            return tokenResponse.Token;
        }


        public async Task<GetStocks> GetAllStocksAsync(string token, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var stockResponses = new List<SimpleResultStock>();
            string url = "/api/v1/internal/marketplace";

            do
            {
                using var response = await _httpClient.GetAsync(url, cancellationToken);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(cancellationToken);

                // Deserialize the entire response
                var stockResponseList = JsonSerializer.Deserialize<List<SimpleResultStock>>(content)
                                        ?? throw new Exception("Не удалось сериализовать данные об акциях из API.");

                // Add all stocks to the list
                stockResponses.AddRange(stockResponseList);

                // Next URL is not available in this response format
                url = null; // Set url to null to stop the loop

            } while (url != null); // This loop will only run once

            return new GetStocks { Stocks = stockResponses };
        }


        public async Task<UserInfo> GetUserInfoAsync(string token, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("/api/v1/internal/marketplace/user-info", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var userResponse = JsonSerializer.Deserialize<UserResponse>(content)
                               ?? throw new Exception("Не удалось десериализовать данные о пользователе из API.");

            return userResponse.UserInfo;
        }

        public async Task<GetStocks> GetAllMyStocksAsync(string token, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var myStocksResponses = new List<SimpleResultStock>();
            string url = "/api/v1/internal/marketplace/my-stocks";
            string nextUrl;

            do
            {
                using var response = await _httpClient.GetAsync(url, cancellationToken);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(cancellationToken);


                var stockResponseList = JsonSerializer.Deserialize<List<SimpleResultStock>>(content)
                                        ?? throw new Exception("Не удалось сериализовать данные об акциях из API.");


                myStocksResponses.AddRange(stockResponseList);


                url = null;

            } while (url != null);

            return new GetStocks { Stocks = myStocksResponses };
        }

        public async Task<bool> BuyStockAsync(string token, int amount, string ticket,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var requestBody = new { amount, ticket };

                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                using var response =
                    await _httpClient.PostAsJsonAsync("/api/v1/internal/marketplace/buy", requestBody,
                        cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return false;
        }


        public async Task<bool> SellStockAsync(string token, int amount, string ticket,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var requestBody = new { amount, ticket };

                using var response =
                    await _httpClient.DeleteAsync("/api/v1/internal/marketplace/sell", cancellationToken);
                response.EnsureSuccessStatusCode();


                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }

        public async Task<SimpleResultStock> GetSpecificStockAsync(string token, string id,
            CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"/api/v1/internal/marketplace/stock?id={id}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            var stock = JsonSerializer.Deserialize<SimpleResultStock>(content);

            return stock;
        }

        public async Task<float[]> GetPolynomialCoefficientsAsync(string token,
            CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            using var response = await _httpClient.GetAsync("/api/v1/internal/polynomial", cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);

            return (float[])data["polynomialCoefficients"];
        }


        public async Task<bool> RegisterAsync(string displayName, string login, string password,
            CancellationToken cancellationToken = default)
        {
            var requestBody = new { display_name = displayName, login, password };

            using var response =
                await _httpClient.PostAsJsonAsync("/api/v1/internal/register", requestBody, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CheckHealthAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("/health", cancellationToken);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateUserBalanceAsync(string token, int amount,
            CancellationToken cancellationToken = default)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var user_id = "";
                var requestBody = new { amount, user_id };

                using var response =
                    await _httpClient.DeleteAsync("/api/v1/internal/marketplace/update-balance", cancellationToken);
                response.EnsureSuccessStatusCode();


                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
        
        }
}
