using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Exceptions;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IMapper mapper, IBaseRepository<Product> productRepository   )
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync( request.ProductId );
            if( productToDelete == null )
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            await _productRepository.DeleteAsync(productToDelete);
            return Unit.Value;
        }
    }
}
