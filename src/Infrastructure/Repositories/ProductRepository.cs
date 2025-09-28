using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts.Repositories
{

    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Product product, CancellationToken cancellationToken)
        {
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CheckExistByTitleAsync(
            string title,
            CancellationToken cancellationToken,
            int? ignoreId = null)
        {
            var res = await _context.Products
                .Where(i => i.Id != ignoreId)
                .Where(i => i.Title.Contains(title))
                .AnyAsync(cancellationToken);

            return res;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .AsNoTracking()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return product;

        }

        public async Task<bool> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            try
            {
                product.LastModifiedOn = DateTime.Now;
                _context.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
