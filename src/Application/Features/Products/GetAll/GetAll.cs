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
                ParentId = i.ParentId,
                Title = i.Title,

                CreatedOn = i.CreatedOn,
                CreatorFullName=i.Creator.FullName,
                LastModifiedOn = i.LastModifiedOn,
                LastModifierFullName=i.LastModifier?.FullName,
            }).ToList();

            return Result<List<GetAllProductResponse>>.Success(res);

        }
    }
}
