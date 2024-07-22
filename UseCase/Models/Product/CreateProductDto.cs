using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace UseCase.Models.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        
        public string Image { get; set; }
        
        public string Category { get; set; }
        
        public decimal? Discount { get; set; }
        
        public decimal Price { get; set; }
        
        public bool IsValid { get; set; } = true;
        
        public bool IsCombo { get; set; } = false;
        public string? Description { get; set; }
    }

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Not empty");
            RuleFor(x => x.Name).NotNull().WithMessage("Not null");

            RuleFor(x => x.Image).NotEmpty().WithMessage("Not empty");
            RuleFor(x => x.Image).NotNull().WithMessage("Not null");

            RuleFor(x => x.Category).NotEmpty().WithMessage("Not empty");
            RuleFor(x => x.Category).NotNull().WithMessage("Not null");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Not empty");
            RuleFor(x => x.Price).NotNull().WithMessage("Not null");
            RuleFor(x => x.Price).NotEqual(0).WithMessage("Not 0");

            RuleFor(x => x.Discount).NotEmpty().NotNull().Equal(0).WithMessage("not 0");
        }
    }
}
