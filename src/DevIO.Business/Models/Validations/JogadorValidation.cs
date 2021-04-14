using DevIO.Business.DTO;
using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class JogadorValidation : AbstractValidator<JogadorPutModelDto>
    {
        public JogadorValidation()
        {
            RuleFor(f => f.IdClash).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(f => f.Email).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}