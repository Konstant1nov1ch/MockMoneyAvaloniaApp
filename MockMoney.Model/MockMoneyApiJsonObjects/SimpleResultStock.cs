using System.Text.Json.Serialization;

namespace MockMoney.Model.MockMoneyApiJsonObjects;

public class SimpleResultStock
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("ticket")]
    public string Ticket { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("lot_size")]
    public int LotSize { get; set; }

    [JsonPropertyName("price_step")]
    public int PriceStep { get; set; }

    [JsonPropertyName("is_short")]
    public int IsShort { get; set; }

    [JsonPropertyName("logo")]
    public string Logo { get; set; }

    [JsonPropertyName("graphic_function")]
    public string GraphicFunction { get; set; }
}
