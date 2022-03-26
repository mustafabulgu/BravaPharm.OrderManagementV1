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

namespace BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IBaseRepository<Category> _categoryRepository;

        public GetProductDetailQueryHandler(IMapper mapper, IBaseRepository<Product> productRepository, IBaseRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if(product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            var productDto = _mapper.Map<ProductDetailVm>(product);

            var category = await _categoryRepository.GetByIdAsync(productDto.CategoryId);
            productDto.Category = _mapper.Map<CategoryDto>(category);
            return productDto;
        }
    }
}
