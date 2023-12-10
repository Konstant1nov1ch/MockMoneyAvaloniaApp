using MediatR;

namespace MockMoney.Commands.GetPolynomialCoefficientsApi;

public sealed record GetPolynomialCoefficientsApiRequest(string Token) : IRequest<GetPolynomialCoefficientsApiResponse>
{
}
