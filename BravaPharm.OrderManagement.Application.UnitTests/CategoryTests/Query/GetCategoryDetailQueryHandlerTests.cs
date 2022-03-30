using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryList;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Application.Profiles;
using BravaPharm.OrderManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BravaPharm.OrderManagement.Application.UnitTests.CategoryTests.Query
{
    public class GetCategoryDetailQueryHandlerTests
    {
        private IMapper _mapper;
        private Mock<ICategoryRepository> _mockCategoryRepository;
        public GetCategoryDetailQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var mappingConfig = new MapperConfiguration(mapExp =>
            {
                mapExp.AddProfile<MappingProfile>();
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCategoryListQueryHandler_ShouldReturnCategorySimpleVmList()
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);
            
            var cateogories = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);
            cateogories.ShouldBeOfType<List<CategorySimpleVm>>();
            cateogories.Count.ShouldBe(4);
        }

    }   
}
