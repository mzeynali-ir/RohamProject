using Api.Controllers.Common;
using Application.Features.Products;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductController : RootController
    {

        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            var res = await _productService.CreateAsync(request, cancellationToken);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateProductRequest request,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            request.SetId(id);
            var res = await _productService.UpdateAsync(request, cancellationToken);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var res = await _productService.GetByIdAsync(id, cancellationToken);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            CancellationToken cancellationToken)
        {
            var res = await _productService.GetAllAsync(cancellationToken);
            return Ok(res);
        }

    }
}
