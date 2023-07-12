using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId
{
    public class GetAllMerchantProductsByMerchantIdQuery : IRequest<PagedResponse<List<GetAllMerchantProductByMerchantIdViewModel>>>
    {

        public int MerchantId { get; set; }


        public class GetAllMerchantProductsByMerchantIdQueryHandler : IRequestHandler<GetAllMerchantProductsByMerchantIdQuery, PagedResponse<List<GetAllMerchantProductByMerchantIdViewModel>>> {
            private readonly IMerchantProductRepositoryAsync _merchantProductRepositoryAsync;
            public GetAllMerchantProductsByMerchantIdQueryHandler(IMerchantProductRepositoryAsync repo)
            {
                _merchantProductRepositoryAsync = repo;
            }

            public async Task<PagedResponse<List<GetAllMerchantProductByMerchantIdViewModel>>> Handle(GetAllMerchantProductsByMerchantIdQuery request, CancellationToken cancellationToken)
            {
                var list = await _merchantProductRepositoryAsync.GetMerhantProductByMerchantId(request.MerchantId);
                return new PagedResponse<List<GetAllMerchantProductByMerchantIdViewModel>>(list, 1, 10);


            }


        }
    } }
