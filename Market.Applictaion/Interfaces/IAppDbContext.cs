using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Market.Applictaion.Interfaces
{
    public interface IAppDbContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
    }
}
