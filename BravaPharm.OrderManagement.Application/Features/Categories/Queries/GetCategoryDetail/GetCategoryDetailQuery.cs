using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryDetailQuery  : IRequest<CategoryDetailVm>
    {
        public Guid Id { get; set; }
    }
}
