using Market.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ProductExists(string name, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task UpdateAsync(Product product, CancellationToken cancellationToken);
        Task RemoveAsync(Product product, CancellationToken cancellationToken);
    }
}
