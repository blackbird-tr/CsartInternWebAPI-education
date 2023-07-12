using AutoMapper;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Merchants.Queries.GetAllMerchant
{
    public class GetAllMerchantQuery:IRequest<PagedResponse<IEnumerable<GetAllMerchantViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
    public class GetAllMerchnatQueryHandler:IRequestHandler<GetAllMerchantQuery,PagedResponse<IEnumerable<GetAllMerchantViewModel>>>
    {
        private readonly IMerchantRepositoryAsync _merchantRepository;
        private readonly IMapper _mapper;

        public GetAllMerchnatQueryHandler(IMerchantRepositoryAsync merchantRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllMerchantViewModel>>> Handle(GetAllMerchantQuery request,CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMerchantParameter>(request);
            var merchant = await _merchantRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var merchantviewmodel=_mapper.Map<IEnumerable<GetAllMerchantViewModel>>(merchant);
            return new PagedResponse<IEnumerable<GetAllMerchantViewModel>>(merchantviewmodel, validFilter.PageNumber, validFilter.PageSize);

        }
    }
}
