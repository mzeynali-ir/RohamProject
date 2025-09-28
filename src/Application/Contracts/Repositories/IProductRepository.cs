using Domain.Entities;

namespace Application.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> CheckExistByTitleAsync(string title, CancellationToken cancellationToken, int? ignoreId = null);
    }
}
