using Application.DTOs;

namespace Application.Features.Products
{

    public partial class ProductService : IProductService
    {
        public async Task<Result<GetByIdProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {

            var product = await _repository.GetByIdAsync(id, cancellationToken);

            if (product is null)
            {
                return Result<GetByIdProductResponse>.Failure(ProductMessages.NotFound);
            }

            var res = new GetByIdProductResponse()
            {
                Id = product.Id,
                Title = product.Title,
            };

            return Result<GetByIdProductResponse>.Success(res);

        }
    }

}
