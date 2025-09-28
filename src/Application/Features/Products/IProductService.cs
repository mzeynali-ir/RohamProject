using Application.DTOs;

namespace Application.Features.Products
{
    public interface IProductService
    {

        Task<Result> CreateAsync(CreateProductRequest input, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(UpdateProductRequest input, CancellationToken cancellationToken);
        Task<Result<GetByIdProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<List<GetAllProductResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result> DeleteAsync(int id, CancellationToken cancellationToken);

    }
}
