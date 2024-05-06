using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Api.Controllers
{
    [EnableRateLimiting("fixed")]
    [Route("api/products")]
    [ApiController]
    public class ProductController(ISender _sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts(
            string? searchTerm,
            int? maxPrice,
            int? minPrice,
            int page = 1,
            int pageSize = 100)
        {
            var query = new GetProductsQuery(searchTerm,maxPrice,minPrice,page,pageSize);
            return Ok(await _sender.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] GetProductByIdQuery getProductByIdQuery)
        {
            return Ok(await _sender.Send(getProductByIdQuery));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            return Ok(await _sender.Send(createProductCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand deleteProductCommand)
        {           
            return Ok(await _sender.Send(deleteProductCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] UpdateProductCommand updateProductCommand)
        {
            return Ok(await _sender.Send(updateProductCommand));
        }
    }
}
