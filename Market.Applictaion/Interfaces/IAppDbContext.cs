using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Market.Applictaion.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
