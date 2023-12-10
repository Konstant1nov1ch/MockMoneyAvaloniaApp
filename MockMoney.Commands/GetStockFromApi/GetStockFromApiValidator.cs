using FluentValidation;
using MockMoney.Commands.GetStockFromApi;

namespace MockMoney.Commands.GetStock;

public class GetStockFromApiValidator : AbstractValidator<GetStockFromApiRequest>
{
    public GetStockFromApiValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Please provide a valid token.");
        RuleFor(x => x.Ticket)
            .NotEmpty()
            .WithMessage("Please provide a valid stock ticket.");
    }
}
