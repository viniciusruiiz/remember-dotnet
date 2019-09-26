using FluentValidation;
using Remember.Domain.Arguments;
using System;

namespace Remember.Domain.Validators
{
    public class SignUpValidator : AbstractValidator<SignUpRequest>
    {
        //TODO: Set messages
        public SignUpValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("nome null")
                .MinimumLength(4).WithMessage("nome menor")
                .MaximumLength(60).WithMessage("nome maior");

            RuleFor(x => x.BirthDate)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-8).Date).WithMessage("muito novo");

            RuleFor(x => x.Gender)
                .NotNull().WithMessage("genero obrigatorio")
                .Must(x => x == 'm' || x == 'f' || x == 'u').WithMessage("genero invalido");

            //TODO: EmailVO
            //RuleFor(x => x.Email)

            //TODO: PasswordVO
            //RuleFor(x => x.Password)
        }
    }
}
