using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BravaPharm.OrderManagement.Persistence
{
    public class BravaPharmDbContextSeeder
    {
        public static async Task SeedAsync(BravaPharmDbContext bravaPharmDbContext)
        {
           if(bravaPharmDbContext.Database.IsSqlServer())
            {
                bravaPharmDbContext.Database.Migrate();
            }

            //seed
            var medicineGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var babyGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var toileteryGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var skinCareGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            if (!await bravaPharmDbContext.Categories.AnyAsync())
            {
               
                await bravaPharmDbContext.Categories.AddRangeAsync(
                    new Category { CategoryId = medicineGuid, Name = "Medicines" },
                    new Category { CategoryId = babyGuid, Name = "Baby" },
                    new Category { CategoryId = toileteryGuid, Name = "Toilteries" },
                    new Category { CategoryId = skinCareGuid, Name = "Skin Care" }
                );
                await bravaPharmDbContext.SaveChangesAsync();
            }
            if(! await bravaPharmDbContext.Products.AnyAsync())
            {
                await bravaPharmDbContext.Products.AddRangeAsync(
                 new Product
                 {
                     ProductId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                     CategoryId = medicineGuid,
                     Description = "Pain killer",
                     ProductName = "Nurofen",
                     Price = 3,
                     ImageUrl = "https://pharmacyartifacts.blob.core.windows.net/images/nurofen.jpg"
                 },

                 new Product
                 {
                     ProductId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                     CategoryId = babyGuid,
                     Description = "Formula Milk",
                     ProductName = "SMA",
                     Price = 5,
                     ImageUrl = "https://pharmacyartifacts.blob.core.windows.net/images/sma.jpg"
                 },

                new Product
                {
                    ProductId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                    CategoryId = toileteryGuid,
                    Description = "Anti bacterial Soap",
                    ProductName = "Carex",
                    Price = 15,
                    ImageUrl = "https://pharmacyartifacts.blob.core.windows.net/images/carex.jpg"
                },

               new Product
               {
                   ProductId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                   CategoryId = skinCareGuid,
                   Description = "Moisturising cream",
                   ProductName = "Nivea",
                   Price = 10,
                   ImageUrl = "https://pharmacyartifacts.blob.core.windows.net/images/nivea.jpg"
               });
               
                await bravaPharmDbContext.SaveChangesAsync();
            }
        }
    }
}
