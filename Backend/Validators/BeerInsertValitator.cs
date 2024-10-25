using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerInsertValitator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValitator() {
            RuleFor(x => x.Name).NotEmpty();
        }
        

    }
}
