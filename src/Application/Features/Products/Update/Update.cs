using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {
        public async Task<Result> UpdateAsync(UpdateProductRequest input, int userId, CancellationToken cancellationToken)
        {

            var product = await _repository.GetByIdAsync(input.Id, cancellationToken);

            if (product is null)
            {
                return Result.Failure(ProductMessages.NotFound);
            }

            var checkDuplicateTitle = await _repository.CheckExistByTitleAsync(
                                                        title: input.Title,
                                                        cancellationToken,
                                                        ignoreId: input.Id);

            if (checkDuplicateTitle)
            {
                return Result.Failure(ProductMessages.NameIsDuplicate);
            }

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

                product.SetParent(parent);

            }

            product.Title = input.Title;

            var dbRes = await _repository.UpdateAsync(product, userId, cancellationToken);

            if (dbRes is false)
            {
                return Result.Failure(ProductMessages.ErrorInUpdate);
            }

            return Result.Success();

        }
    }

}
