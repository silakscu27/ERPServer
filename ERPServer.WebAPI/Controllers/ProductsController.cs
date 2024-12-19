using ERPServer.Application.Features.Products.CreateProduct;
using ERPServer.Application.Features.Products.DeleteProductById;
using ERPServer.Application.Features.Products.GetAllProduct;
using ERPServer.Application.Features.Products.GetProductById;
using ERPServer.Application.Features.Products.UpdateProduct;
using ERPServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERPServer.WebAPI.Controllers;

public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductByIdQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductByIdCommand(id);
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
