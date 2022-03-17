using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductList;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Products;

public class GetProductListQuery : IRequest<List<ProductSimpleVm>>
{

}
