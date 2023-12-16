using System.Text.Json.Serialization;

namespace MockMoney.Model.MockMoneyApiJsonObjects;

public class GetTokenFromApi
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}