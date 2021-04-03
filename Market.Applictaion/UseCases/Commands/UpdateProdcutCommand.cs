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
    public class UpdateProdcutCommand : IRequest<ResponseModel>
    {
        public UpdateProdcutCommand(UpdateProductDTO product)
        {
            Product = product;
        }

        public UpdateProductDTO Product { get; set; }

        public class UpdateProdcutCommandHandler : IRequestHandler<UpdateProdcutCommand, ResponseModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProdcutCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ResponseModel> Handle(UpdateProdcutCommand request, CancellationToken cancellationToken)
            {
                var targetProduct = await _productRepository.GetByIdAsync(request.Product.Id, cancellationToken);
                if (targetProduct == null)
                {
                    return ResponseModel.Create(ResponseCode.DoesNotExist);
                }
                if (await _productRepository.ProductExists(request.Product.Name, request.Product.Id, cancellationToken))
                {
                    return ResponseModel.Create(ResponseCode.AlreadyExists);
                }
                var sourceProduct = _mapper.Map<Product>(request.Product);
                if (targetProduct.Equals(sourceProduct))
                {
                    return ResponseModel.Create(ResponseCode.NoChangesAreDone);
                }
                targetProduct.Update(sourceProduct);
                await _productRepository.UpdateAsync(targetProduct, cancellationToken);
                return ResponseModel.Create(ResponseCode.SuccessfullyUpdate);
            }
        }
    }
}
