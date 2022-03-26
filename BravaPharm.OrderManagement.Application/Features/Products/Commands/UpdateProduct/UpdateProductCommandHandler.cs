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

namespace BravaPharm.OrderManagement.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _productRepository;

        public UpdateProductCommandHandler(IMapper mapper, IBaseRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
            productToUpdate =_mapper.Map<Product>(request);
            await _productRepository.UpdateAsync(productToUpdate);
            return  Unit.Value;
        }
    }
}
