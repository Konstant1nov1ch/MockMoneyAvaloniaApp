using MediatR;
using MockMoney.Abstractions.HttpClients;
using Newtonsoft.Json;

namespace MockMoney.Commands.GetPolynomialCoefficientsApi;

public sealed class GetPolynomialCoefficientsHandler : IRequestHandler<GetPolynomialCoefficientsApiRequest, GetPolynomialCoefficientsApiResponse>
{
    private readonly IMockMoneyHttpClient _httpClient;

    public GetPolynomialCoefficientsHandler(IMockMoneyHttpClient httpClient) => 
        _httpClient = httpClient;

    public async Task<GetPolynomialCoefficientsApiResponse> Handle(GetPolynomialCoefficientsApiRequest request, CancellationToken cancellationToken)
    {
        // Use request parameters directly
        var token = request.Token;
        var resp = await _httpClient.GetPolynomialCoefficientsAsync(token, cancellationToken);

        // Simplify response object creation
        return new GetPolynomialCoefficientsApiResponse
        {
            PolynomialCoefficients = resp
        };
    }
}
