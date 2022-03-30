using BravaPharm.OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using Moq;

namespace BravaPharm.OrderManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var medicineGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var babyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var toileteryGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var skinCareGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = medicineGuid,
                    Name = "Medicines"
                },
                new Category
                {
                    CategoryId = babyGuid,
                    Name = "Baby"
                },
                new Category
                {
                    CategoryId = toileteryGuid,
                    Name = "Toilteries"
                },
                 new Category
                {
                    CategoryId = skinCareGuid,
                    Name = "Skin Care"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);
            mockCategoryRepository.Setup(repo => repo.IsUniqueCategory("Unique Category")).ReturnsAsync(true);
            mockCategoryRepository.Setup(repo => repo.CreateAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCategoryRepository;

        }
    }
}
