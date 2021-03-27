using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.UseCases.Commands
{
    public class DeleteProductCommand : IRequest<ResponseModel>
    {
        public DeleteProductCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseModel>
        {
            private readonly IProductRepository _productRepository;

            public DeleteProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<ResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
                if (product == null)
                {
                    return ResponseModel.Create(ResponseCode.DoesNotExist);
                }
                await _productRepository.RemoveAsync(product, cancellationToken);
                return ResponseModel.Create(ResponseCode.SuccessfullyDeleted);
            }
        }

    }
}
