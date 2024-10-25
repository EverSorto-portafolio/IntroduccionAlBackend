using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator() {
            RuleFor(x => x.Id).NotNull().WithMessage("El Id es obligatorio");
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre el obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("Sebe ser entre 2 a 20 caracteres");
            RuleFor(x => x.BrandID).NotNull().WithMessage("Debe ingresar una marca de serveza valida");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("La marca debe estar registrada");
            RuleFor(x => x.Al).GreaterThan(0).WithMessage(x => "El nivel de alcohol  {PropertyName} debe ser legal");

        }
    }
}
