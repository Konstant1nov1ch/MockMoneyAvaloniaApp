using System.Text.Json.Serialization;

namespace MockMoney.Model.MockMoneyApiJsonObjects;
public class UserInfo
{
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
}

public class UserResponse
{
    [JsonPropertyName("user_info")]
    public UserInfo UserInfo { get; set; }
}

