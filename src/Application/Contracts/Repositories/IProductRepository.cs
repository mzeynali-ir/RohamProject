using Domain.Entities.Products;

namespace Application.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product, int userId, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Product product, int userId, CancellationToken cancellationToken);
        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id,int userId, CancellationToken cancellationToken);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> CheckExistByTitleAsync(string title, CancellationToken cancellationToken, int? productId = null);
    }
}
