using Market.Applictaion.Interfaces;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ProductExists(string name, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(x => x.Name == name, cancellationToken);
        }

        public async Task<bool> ProductExists(string name, long id, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(x => x.Name == name && x.Id != id, cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            //_context.Database.ExecuteSqlRaw(
            //  "UPDATE dbo.Products SET Available = 0 WHERE Id = 7");
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
