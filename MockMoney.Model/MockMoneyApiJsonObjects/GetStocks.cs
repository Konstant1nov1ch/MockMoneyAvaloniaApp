using System.Text.Json.Serialization;

namespace MockMoney.Model.MockMoneyApiJsonObjects;

public class GetStocks
{
    [JsonPropertyName("items")]
    public List<SimpleResultStock> Stocks { get; set; }
}
