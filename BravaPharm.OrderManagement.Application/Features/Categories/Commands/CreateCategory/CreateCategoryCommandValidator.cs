using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Features.Products.Commands.CreateProduct;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using FluentValidation;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(c => c.Name).NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not be more than 50 characters");
            RuleFor(c => c).MustAsync(CheckUniquieCategory).WithMessage("Category must be unique");
        }



        private async Task<bool> CheckUniquieCategory(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            return await _categoryRepository.IsUniqueCategory(command.Name);
        }
    }
}
