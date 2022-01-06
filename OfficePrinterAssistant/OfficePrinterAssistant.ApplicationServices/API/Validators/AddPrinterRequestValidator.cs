using FluentValidation;
using OfficePrinterAssistant.ApplicationServices.API.Domain;

namespace OfficePrinterAssistant.ApplicationServices.API.Validators
{
    public class AddPrinterRequestValidator : AbstractValidator<AddPrinterRequest>
    {
        public AddPrinterRequestValidator()
        {
            this.RuleFor(x => x.SerialNumber).Length(1, 10).WithMessage("Range Should be bettween 1 - 10");
        }
    }
}
