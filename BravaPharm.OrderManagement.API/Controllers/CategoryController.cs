﻿using System;
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
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name ="GetAllCategories")]
        public async Task<ActionResult<List<CategorySimpleVm>>> GetAllCategories()
        {
            _logger.LogInformation("Getting all Categories");
            var request = new GetCategoryListQuery();
            var response =   await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getbyid", Name = "GetCategoryDetails")]
        public async Task<ActionResult<CategoryDetailVm>> GetCategory(Guid id)
        {
            _logger.LogInformation($"Getting category details {id}");
            var request = new GetCategoryDetailQuery { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(Name ="AddCategory")]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody]CreateCategoryCommand createCategoryCommand)
        {
            _logger.LogInformation($"Adding category {createCategoryCommand.Name}");
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
