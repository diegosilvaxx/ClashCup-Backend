using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class TorneioValidation : AbstractValidator<Torneio>
    {
        public TorneioValidation()
        {
            RuleFor(c => c.NomeTorneio)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}