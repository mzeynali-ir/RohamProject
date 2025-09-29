using Domain.Entities;
using Domain.Entities.ProductLogs;
using Domain.Entities.Products;
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

        public async Task<bool> AddAsync(Product product, int userId, CancellationToken cancellationToken)
        {
            try
            {
                product.CreatorId = userId;
                _context.Add(product);

                var log = new ProductLog()
                {
                    CreatorId = userId,
                    CreatedOn = product.CreatedOn,
                    Type = LogActionType.Add,
                    Product = product,
                };
                _context.ProductLogs.Add(log);

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

        public async Task<bool> DeleteAsync(int id, int userId, CancellationToken cancellationToken)
        {
            try
            {
                var product = await this.GetByIdAsync(id, cancellationToken);
                if (product is null)
                    return false;

                var now = DateTime.Now;

                product.Delete();
                product.LastModifiedOn = now;
                product.LastModifierId = userId;
                _context.Update(product);

                var log = new ProductLog()
                {
                    CreatorId = userId,
                    CreatedOn = now,
                    Type = LogActionType.Delete,
                    Product = product,
                };
                _context.ProductLogs.Add(log);

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(i => i.Creator)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Include(i => i.Creator)
                .FirstOrDefaultAsync(cancellationToken);

            return product;

        }

        public async Task<bool> UpdateAsync(Product product, int userId, CancellationToken cancellationToken)
        {
            try
            {
                var now = DateTime.Now;

                product.LastModifiedOn = now;
                product.LastModifierId = userId;
                _context.Update(product);

                var log = new ProductLog()
                {
                    CreatorId = userId,
                    CreatedOn = now,
                    Type = LogActionType.Update,
                    ProductId = product.Id,
                };
                _context.ProductLogs.Add(log);

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
