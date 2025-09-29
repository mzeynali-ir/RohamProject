using Application.Contracts.Repositories;
using Application.DTOs;

namespace Application.Features.Products
{
    public partial class ProductService : IProductService
    {

        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        private async Task<Result> CheckParentAsync(int parentId, CancellationToken cancellationToken)
        {
            var parent = await _repository.GetByIdAsync(parentId, cancellationToken);

            if (parent is null)
            {
                return Result.Failure(ProductMessages.ParentNotFound);
            }

            if (parent.CanAddChild() is false)
            {
                return Result.Failure(ProductMessages.ParentDepthOwerFlow);
            }

            return Result.Success();
        }

    }
}
