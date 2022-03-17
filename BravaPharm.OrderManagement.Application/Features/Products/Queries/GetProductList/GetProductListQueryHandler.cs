using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductSimpleVm>>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _productRepository;

        public GetProductListQueryHandler(IMapper mapper, IBaseRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<List<ProductSimpleVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductSimpleVm>>(allProducts);
        }
    }
}
