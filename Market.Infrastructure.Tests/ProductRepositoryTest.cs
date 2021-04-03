using Market.Domain.Entities;
using Market.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Infrastructure.Tests
{
    public class ProductRepositoryTest
    {
        private AppDbContext _context;
        private ProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(GetInMemoryOptions());
            _productRepository = new ProductRepository(_context);
        }

        [Test]
        [TestCase("Shirt", true)]
        [TestCase("Shoes", false)]
        public async Task ProductExists_ShouldReturnResult(string name, bool alreadyExists)
        {
            //Arrange
            CancellationToken token = new CancellationToken();
            await InsertData(token);

            //Act
            var queryResult = await _productRepository.ProductExists(name, token);

            //Assert
            Assert.AreEqual(queryResult, alreadyExists);
        }


        [Test]
        [TestCase("Shirt", 2, true)]
        [TestCase("Shirt", 1, false)]
        public async Task ProductExists_ShouldReturnResult(string name, long id, bool alreadyExists)
        {
            //Arrange
            CancellationToken token = new CancellationToken();
            await InsertData(token);

            //Act
            var queryResult = await _productRepository.ProductExists(name, id, token);

            //Assert
            Assert.AreEqual(queryResult, alreadyExists);
        }
        [Test]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        public async Task GetByIdAsync_ShouldReturnProduct(long id, bool hasData)
        {
            //Arrange
            CancellationToken token = new CancellationToken();
            await InsertData(token);

            //Act
            var queryResult = await _productRepository.GetByIdAsync(id, token);

            //Assert
            Assert.AreEqual(queryResult != null, hasData);
        }


        private DbContextOptions<AppDbContext> GetInMemoryOptions()
        {
            var serviceProvider = new ServiceCollection()
               .AddEntityFrameworkInMemoryDatabase()
               .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("FakeDB")
                .UseInternalServiceProvider(serviceProvider)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return options;
        }

        public async Task InsertData(CancellationToken token)
        {
            await _context.Products.AddRangeAsync(new List<Product>
            {
                new Product(1, "Shirt", 10, true, "yellow shirt", DateTime.Now),
                new Product(2, "Dress", 50, true, "evening dress", DateTime.Now)
            }, token);
            await _context.SaveChangesAsync(token);
        }
    }
}
