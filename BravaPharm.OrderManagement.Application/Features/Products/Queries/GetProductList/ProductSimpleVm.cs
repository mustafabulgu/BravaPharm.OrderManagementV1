using BravaPharm.OrderManagement.Domain.Entities;

namespace BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductList
{
    public class ProductSimpleVm
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}