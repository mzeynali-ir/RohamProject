using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {
        public async Task<Result> CreateAsync(CreateProductRequest input, CancellationToken cancellationToken)
        {

            var isExist = await _repository.CheckExistByTitleAsync(
                                            input.Title,
                                            cancellationToken);

            if (isExist)
            {
                return Result.Failure(ProductMessages.NameIsDuplicate);
            }

            var product = new Product()
            {
                Title = input.Title,
            };

            var dbRes = await _repository.AddAsync(product, cancellationToken);

            if (dbRes is false)
            {
                return Result.Failure(ProductMessages.ErrorInAdd);
            }

            return Result.Success();

        }
    }
}
