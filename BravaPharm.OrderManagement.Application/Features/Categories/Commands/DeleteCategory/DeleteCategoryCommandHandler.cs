using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Exceptions;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryToDelete == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            var validator = new DeleteCategoryCommandValidator(_categoryRepository);
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            
            await _categoryRepository.DeleteAsync(categoryToDelete);
            
            return Unit.Value;
        }
    }
}
