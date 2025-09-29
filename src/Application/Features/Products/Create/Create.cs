using Application.DTOs;
using Domain.Entities.Products;

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

            if (input.ParentId is not null)
            {
                var checkParent = await this.CheckParentAsync(parentId: input.ParentId.Value, cancellationToken);
                if (checkParent.IsSuccess is false)
                {
                    return checkParent;
                }
            }

            var product = new Product()
            {
                Title = input.Title,
            };

            var dbRes = await _repository.AddAsync(product, userId, cancellationToken);

            if (input.ParentId is not null)
            {
                var parent = await _repository.GetByIdAsync(input.ParentId.Value, cancellationToken);
                product!.SetParent(parent!);
            }
            else
            {
                product.ResetParentPath();
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
