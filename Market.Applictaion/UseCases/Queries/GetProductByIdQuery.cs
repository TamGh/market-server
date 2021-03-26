using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.UseCases.Queries
{
    public class GetProductByIdQuery : IRequest<ResponseModel<ProductViewDTO>>
    {
        public GetProductByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ResponseModel<ProductViewDTO>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<ProductViewDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var queryResult = _mapper.Map<ProductViewDTO>(await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id));
                if (queryResult == null)
                {
                    ResponseModel<ProductViewDTO>.Create(ResponseCode.DoesNotExist, queryResult);
                }
                return ResponseModel<ProductViewDTO>.Create(ResponseCode.Success, queryResult);
            }
        }

    }
}
