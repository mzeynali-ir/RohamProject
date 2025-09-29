using Application.DTOs;

namespace Application.Features.Products
{

    public partial class ProductService : IProductService
    {
        public async Task<Result> DeleteAsync(int id, int userId, CancellationToken cancellationToken)
        {

            var product = await _repository.GetByIdAsync(id, cancellationToken);

            if (product is null)
            {
                return Result.Failure(ProductMessages.NotFound);
            }

            if (product.HasChild())
            {
                return Result.Failure(ProductMessages.HasChildWhenDelete);
            }

            var dbRes = await _repository.DeleteAsync(id, userId, cancellationToken);

            if (dbRes is false)
            {
                return Result.Failure(ProductMessages.ErrorInUpdate);
            }

            return Result.Success();

        }
    }

}
