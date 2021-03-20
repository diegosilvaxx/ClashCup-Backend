using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(f => f.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.CPF).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").MaximumLength(14).MinimumLength(14).WithMessage("O campo {PropertyName} deve conter 14 numeros");
        }
    }
}