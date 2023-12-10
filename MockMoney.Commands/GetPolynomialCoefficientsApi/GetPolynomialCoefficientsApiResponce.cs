namespace MockMoney.Commands.GetPolynomialCoefficientsApi;


public sealed record GetPolynomialCoefficientsApiResponse
{
    public required float[] PolynomialCoefficients { get; init; }
}
