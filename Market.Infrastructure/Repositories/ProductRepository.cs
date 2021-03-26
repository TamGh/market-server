using Market.Applictaion.Interfaces;
using Market.Domain.Models;
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

        public async Task AddAsync(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
