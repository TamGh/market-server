using AutoMapper;
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
    public class UpdateProductCommandTest
    {
        [TestCaseSource(nameof(UpdateProductData))]
        public async Task UpdateProductCommandTest_ShouldReturtCorrectResponse(UpdateProductDTO productDTO, Product mappedProduct, Product retrivedProduct, bool productAlreadyExists, ResponseModel response)
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(retrivedProduct));
            mockProductRepository.Setup(x => x.ProductExists(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(productAlreadyExists));
            mockProductRepository.Setup(x => x.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(default(object)));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Product>(It.IsAny<UpdateProductDTO>())).Returns(mappedProduct);

            //Act
            var handler = new UpdateProdcutCommand.UpdateProdcutCommandHandler(mockProductRepository.Object, mockMapper.Object);
            var handledResponse = await handler.Handle(new UpdateProdcutCommand(productDTO), new CancellationToken());

            //Assert
            Assert.AreEqual(handledResponse.ResponseType, response.ResponseType);
            Assert.AreEqual(handledResponse.Message, response.Message);
        }

        public static IEnumerable<object[]> UpdateProductData =>
           new List<object[]>
           {
                  new object[] { new UpdateProductDTO(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 20, true, "yellow shirt"), false, ResponseModel.Create(ResponseCode.SuccessfullyUpdate) },
                  new object[] { new UpdateProductDTO(2, "Shirt", 10, true, "yellow shirt"), new Product(2, "Shirt", 10, true, "yellow shirt"), null, false, ResponseModel.Create(ResponseCode.DoesNotExist) },
                  new object[] { new UpdateProductDTO(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 20, true, "yellow shirt"), true, ResponseModel.Create(ResponseCode.AlreadyExists) },
                  new object[] { new UpdateProductDTO(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 10, true, "yellow shirt"), new Product(1, "Shirt", 10, true, "yellow shirt"), false, ResponseModel.Create(ResponseCode.NoChangesAreDone) }
           };
    }
}
