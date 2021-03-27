using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using Market.Applictaion.UseCases.Commands;
using Market.Domain.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Tests.UseCases
{
    public class DeleteProductCommandTest
    {
        [TestCaseSource(nameof(DeleteProductData))]
        public async Task DeleteProductCommandTest_ShouldReturtCorrectResponse(long productId, Product retrivedProduct, ResponseModel response)
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(retrivedProduct));
            mockProductRepository.Setup(x => x.RemoveAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(default(object)));

            //Act
            var handler = new DeleteProductCommand.DeleteProductCommandHandler(mockProductRepository.Object);
            var handledResponse = await handler.Handle(new DeleteProductCommand(productId), new CancellationToken());

            //Assert
            Assert.AreEqual(handledResponse.ResponseType, response.ResponseType);
            Assert.AreEqual(handledResponse.Message, response.Message);
        }

        public static IEnumerable<object[]> DeleteProductData =>
           new List<object[]>
           {
                  new object[] { 1, new Product(1, "Shirt", 10, true, "yellow shirt"), ResponseModel.Create(ResponseCode.SuccessfullyDeleted) },
                  new object[] { 1, null, ResponseModel.Create(ResponseCode.DoesNotExist) }
           };
    }
}
