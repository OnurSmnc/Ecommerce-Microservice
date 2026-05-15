using CatalogService.Application.Features.Categories.Commands.CreateCategory;
using CatalogService.Application.Features.Categories.Queries;
using CatalogService.Application.Features.Products.Commands.CreateProducts;
using CatalogService.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductsCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
