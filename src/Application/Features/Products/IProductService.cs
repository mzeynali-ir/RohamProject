using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Products
{
    public interface IProductService
    {

        Task<Result> CreateAsync(CreateProductRequest input, int userId, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(UpdateProductRequest input, int userId, CancellationToken cancellationToken);
        Task<Result<GetByIdProductResponse>> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<List<GetAllProductResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result> DeleteAsync(int id, int userId, CancellationToken cancellationToken);

    }
}
