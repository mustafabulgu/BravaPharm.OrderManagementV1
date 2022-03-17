using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryDetailQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryDetailVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryWithProductsAsync(request.Id);
            return _mapper.Map<CategoryDetailVm>(category);
        }
    }
}
