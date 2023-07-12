using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Merchants.Queries.GetMerchantById
{
    public class GetMerchantByIdQuery:IRequest<Response<Merchant>>
    {
       
            public int Id { get; set; }
            public class GetMerchantByIdQueryHandler : IRequestHandler<GetMerchantByIdQuery, Response<Merchant>>
            {
                private readonly IMerchantRepositoryAsync _MerchantRepository;
                public GetMerchantByIdQueryHandler(IMerchantRepositoryAsync MerchantRepository)
                {
                    _MerchantRepository = MerchantRepository;
                }
                public async Task<Response<Merchant>> Handle(GetMerchantByIdQuery query, CancellationToken cancellationToken)
                {
                    var Merchant = await _MerchantRepository.GetByIdAsync(query.Id);
                    if (Merchant == null) throw new ApiException($"Merchant Not Found.");
                    return new Response<Merchant>(Merchant);
                }
            }
        }
    }
