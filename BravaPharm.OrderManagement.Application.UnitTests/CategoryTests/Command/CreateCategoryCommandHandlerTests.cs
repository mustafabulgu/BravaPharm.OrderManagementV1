using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Exceptions;
using BravaPharm.OrderManagement.Application.Features.Categories.Commands.CreateCategory;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Application.Profiles;
using BravaPharm.OrderManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace BravaPharm.OrderManagement.Application.UnitTests.CategoryTests.Command
{
    public class CreateCategoryCommandHandlerTests
    {
        private IMapper _mapper;
        private Mock<ICategoryRepository> _mockCategoryRepository;
        public CreateCategoryCommandHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
          
            var mappingConfig = new MapperConfiguration(mapExp =>
            {
                mapExp.AddProfile<MappingProfile>();
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task CreateCategoryHandler_ShouldAddNewCategoryWhenCategoryNameIsUnique()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);
            var createCategoryCommand = new CreateCategoryCommand { Name = "Unique Category" };
            _ =await handler.Handle(createCategoryCommand, CancellationToken.None);

            var categories = await _mockCategoryRepository.Object.GetAllAsync();
            categories.Count.ShouldBe(5);
            categories.ShouldContain(c => c.Name == "Unique Category");
        }

        [Fact]
        public async Task CreateCategoryHandler_ShouldHaveValidationErrorsWhenCategoryNameIsNotUnique()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);
            var createCategoryCommand = new CreateCategoryCommand { Name = "Baby" };
            var handleAction = async () => { _ = await handler.Handle(createCategoryCommand, CancellationToken.None); };

            await Should.ThrowAsync<ValidationException>(() => handleAction());
            var categories = await _mockCategoryRepository.Object.GetAllAsync();
            categories.Count.ShouldBe(4);
        }
    }
}
