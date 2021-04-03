using AutoMapper;
using Market.Applictaion.DTOs;
using Market.Applictaion.Enums;
using Market.Applictaion.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Applictaion.UseCases.Queries
{
    public class GetProductsQuery : IRequest<ResponseModel<List<ProductListItemDTO>>>
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ResponseModel<List<ProductListItemDTO>>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;

            public GetProductsQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<List<ProductListItemDTO>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var queryResult = await _mapper.ProjectTo<ProductListItemDTO>(_context.Products.AsNoTracking()).ToListAsync(cancellationToken);
                return ResponseModel<List<ProductListItemDTO>>.Create(ResponseCode.Success, queryResult);
            }
        }
    }
}
