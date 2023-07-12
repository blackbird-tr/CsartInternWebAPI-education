using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByProductId
{
    public class GetAllMerchantProductsByProductIdQuery:IRequest<PagedResponse<List<GetAllMerchantProductsByProduxtIdViewModel>>>
    {
        public int ProductId { get; set; }

        public class GetAllMerchantProductsByProductIdQueryHandler : IRequestHandler<GetAllMerchantProductsByProductIdQuery, PagedResponse<List<GetAllMerchantProductsByProduxtIdViewModel>>>
        {
            private readonly IMerchantProductRepositoryAsync _merchantProductRepositoryAsync;
            public GetAllMerchantProductsByProductIdQueryHandler(IMerchantProductRepositoryAsync repo)
            {
                _merchantProductRepositoryAsync = repo;
            }

            public async Task<PagedResponse<List<GetAllMerchantProductsByProduxtIdViewModel>>> Handle(GetAllMerchantProductsByProductIdQuery request, CancellationToken cancellationToken)
            {
                var list = await _merchantProductRepositoryAsync.GetMerchantProductByProductId(request.ProductId);
                return new PagedResponse<List<GetAllMerchantProductsByProduxtIdViewModel>>(list, 1, 10);


            }


        }
    }
}

