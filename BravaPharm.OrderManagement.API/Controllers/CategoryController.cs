using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BravaPharm.OrderManagement.Application.Features.Categories.Commands.CreateCategory;
using BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail;
using BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BravaPharm.OrderManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name ="GetAllCategories")]
        public async Task<ActionResult<List<CategorySimpleVm>>> GetAllCategories()
        {
            var request = new GetCategoryListQuery();
            var response =   await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getbyid", Name = "GetCategoryDetails")]
        public async Task<ActionResult<CategoryDetailVm>> GetCategory(Guid id)
        {
            var request = new GetCategoryDetailQuery { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name ="AddCategory")]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody]CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
