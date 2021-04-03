using Market.Applictaion.DTOs;
using Market.Domain.Entities;
using NUnit.Framework;
using System;

namespace Market.Application.Tests.Mappings
{
    public class ProductMappingTest : MappingBaseTest
    {
        [Test]
        [TestCase(typeof(ProductDTO), typeof(Product))]
        [TestCase(typeof(UpdateProductDTO), typeof(Product))]
        [TestCase(typeof(Product), typeof(ProductListItemDTO))]
        [TestCase(typeof(Product), typeof(ProductViewDTO))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            //Arrange
            var instance = Activator.CreateInstance(source);

            //Act
            var mappingResult = _mapper.Map(instance, source, destination);

            //Assert
            Assert.IsAssignableFrom(destination, mappingResult);
        }
    }
}
