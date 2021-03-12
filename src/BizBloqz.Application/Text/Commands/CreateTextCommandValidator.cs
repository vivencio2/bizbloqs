using FluentValidation;
namespace BizBloqz.Application.Text.Commands
{
    public class CreateTextCommandValidator : AbstractValidator<CreateTextCommand>
    {
        public CreateTextCommandValidator()
        {
            RuleFor(x => x.TextValue).NotNull();
            RuleFor(x => x.TextValue).NotEmpty();
            RuleFor(x => x.TextValue).Must(BeTwentyCharsOnly).WithMessage("Text must be less than 20 characters!");
        }
        private bool BeTwentyCharsOnly(string value)
        {
            if (value.Length > 20) return false;
            return true;
        }
    }
}
