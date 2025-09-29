using Application.DTOs;

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
                                                        productId: input.Id);

            if (checkDuplicateTitle)
            {
                return Result.Failure(ProductMessages.NameIsDuplicate);
            }

            if (input.ParentId is not null)
            {
                var checkParent = await this.CheckParentAsync(parentId: input.ParentId.Value, cancellationToken);
                if (checkParent.IsSuccess is false)
                {
                    return checkParent;
                }
                var parent = await _repository.GetByIdAsync(input.ParentId.Value, cancellationToken);
                product!.SetParent(parent!);
            }
            else
            {
                product.ResetParentPath();
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
