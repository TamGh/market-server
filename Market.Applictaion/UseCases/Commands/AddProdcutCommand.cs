using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using Market.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.UseCases.Commands
{
    public class AddProdcutCommand : IRequest<ResponseModel>
    {
        public AddProdcutCommand(ProductDTO product)
        {
            Product = product;
        }

        public ProductDTO Product { get; set; }

        public class AddProdcutCommandHandler : IRequestHandler<AddProdcutCommand, ResponseModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public AddProdcutCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ResponseModel> Handle(AddProdcutCommand request, CancellationToken cancellationToken)
            {
                if (await _productRepository.ProductExists(request.Product.Name, cancellationToken))
                {
                    return ResponseModel.Create(ResponseCode.AlreadyExists);
                }
                var product = _mapper.Map<Product>(request.Product);
                await _productRepository.AddAsync(product, cancellationToken);
                return ResponseModel.Create(ResponseCode.SuccesfullyCreated);
            }
        }
    }
}
