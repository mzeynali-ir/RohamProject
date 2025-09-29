using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {
        public async Task<Result> CreateAsync(CreateProductRequest input, int userId, CancellationToken cancellationToken)
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

            var dbRes = await _repository.AddAsync(product, userId, cancellationToken);

            if (input.ParentId is not null)
            {

                var parent = await _repository.GetByIdAsync(input.ParentId.Value, cancellationToken);

                if (parent is null)
                {
                    return Result.Failure(ProductMessages.ParentNotFound);
                }

                if (parent.ParentDepth>=Product.MaxParentDepth)
                {
                    return Result.Failure(ProductMessages.ParentDepthOwerFlow);
                }

                product!.SetParent(parent);

            }

            await _repository.UpdateAsync(product, userId, cancellationToken);

            if (dbRes is false)
            {
                return Result.Failure(ProductMessages.ErrorInAdd);
            }

            return Result.Success();

        }
    }
}
