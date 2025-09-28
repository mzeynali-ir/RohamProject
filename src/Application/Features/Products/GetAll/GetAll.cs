using Application.DTOs;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {
        public async Task<Result<List<GetAllProductResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {

            var products = await _repository.GetAllAsync(cancellationToken);

            var res = products.Select(i => new GetAllProductResponse()
            {
                Id = i.Id,
                Title = i.Title,
            }).ToList();

            return Result<List<GetAllProductResponse>>.Success(res);

        }
    }
}
