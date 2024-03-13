using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProductById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(ISender _sender) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroduct([FromRoute] GetProductByIdQuery getProductByIdQuery)
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
