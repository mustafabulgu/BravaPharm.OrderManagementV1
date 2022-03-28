using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Features.Categories.Commands.CreateCategory;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using FluentValidation;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(c => c).MustAsync(NotHaveProductsAsync).WithMessage("Cannot delete category with products.");
        }

        private async Task<bool> NotHaveProductsAsync(DeleteCategoryCommand command, CancellationToken cancellation)
        {

            var category = await _categoryRepository.GetCategoryWithProductsAsync(command.CategoryId);
            return  !(category.Products.Count > 0);
        }
    }
}
