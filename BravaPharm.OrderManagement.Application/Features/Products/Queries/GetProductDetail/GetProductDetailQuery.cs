using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public Guid Id { get; set; }
    }
}
