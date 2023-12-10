using System.Net;
using MockMoney.Abstractions.HttpClients;
using Moq;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async Task GetJwtTokenAsync_OutputsTokenToConsole()
    {
        // Arrange
        const string login = "123123";
        const string password = "123123";

        var mockHttpClient = new Mock<IMockMoneyHttpClient>();
        mockHttpClient.Setup(c =>
                c.GetJwtTokenAsync(login, password, CancellationToken.None))
            .ReturnsAsync("RANDOM_TOKEN");

        // Act
        var token = await mockHttpClient.Object.GetJwtTokenAsync(login, password);

        // Assert
        Console.WriteLine($"Token: {token}");
    }
}