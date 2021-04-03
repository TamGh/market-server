using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using Market.Applictaion.UseCases.Commands;
using Market.Domain.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Tests.UseCases
{
    public class AddProductCommandTest
    {
        [TestCaseSource(nameof(AddProductData))]
        public async Task AddProductCommandTest_ShouldReturtCorrectResponse(ProductDTO productDTO, Product mappedProduct, bool productAlreadyExists, ResponseModel response)
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.ProductExists(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(productAlreadyExists));
            mockProductRepository.Setup(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(default(object)));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Product>(It.IsAny<ProductDTO>())).Returns(mappedProduct);

            //Act
            var handler = new AddProdcutCommand.AddProdcutCommandHandler(mockProductRepository.Object, mockMapper.Object);
            var handledResponse = await handler.Handle(new AddProdcutCommand(productDTO), new CancellationToken());

            //Assert
            Assert.AreEqual(handledResponse.ResponseType, response.ResponseType);
            Assert.AreEqual(handledResponse.Message, response.Message);
        }

        public static IEnumerable<object[]> AddProductData =>
           new List<object[]>
           {
                  new object[] { new ProductDTO("Shirt", 10, true, "yellow shirt"), new Product("Shirt", 10, true, "yellow shirt"), false, ResponseModel.Create(ResponseCode.SuccesfullyCreated) },
                  new object[] { new ProductDTO("Shirt", 10, true, "yellow shirt"), new Product("Shirt", 10, true, "yellow shirt"), true, ResponseModel.Create(ResponseCode.AlreadyExists) }
           };
    }
}
