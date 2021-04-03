using Market.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ProductExists(string name, CancellationToken cancellationToken);
        Task<bool> ProductExists(string name, long id, CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task RemoveAsync(Product product, CancellationToken cancellationToken);
    }
}
