using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Applictaion.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
