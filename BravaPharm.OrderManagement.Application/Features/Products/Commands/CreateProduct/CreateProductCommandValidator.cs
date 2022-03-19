using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using FluentValidation;

namespace BravaPharm.OrderManagement.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not be more than 50 characters");


            RuleFor(p => p.Price).NotEmpty().WithMessage("{PropertyName} is required").GreaterThan(0);
            RuleFor(p => p.Description).NotEmpty().WithMessage("{PropertyName} is required").MinimumLength(50)
                .WithMessage("Please put {PropertyName} more than 50 characters");

            RuleFor(p => p).MustAsync(CheckUniquieProductForCategory).WithMessage("Product should be unique for category");
           
        }

       

        private async Task<bool> CheckUniquieProductForCategory(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return await _productRepository.IsProductUniqueForCategory(command.ProductName, command.CategoryId);
        }
    }
}
