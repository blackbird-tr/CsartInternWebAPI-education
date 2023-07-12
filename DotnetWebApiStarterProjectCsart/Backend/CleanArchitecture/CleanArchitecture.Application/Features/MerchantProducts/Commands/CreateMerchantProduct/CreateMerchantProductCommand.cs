using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.MerchantProducts.Commands.CreateMerchantProduct
{
    public class CreateMerchantProductCommand:IRequest<Response<int>>
    {
        public int MerchantId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }

        public class CreateMerchantProductCommandHandler:IRequestHandler<CreateMerchantProductCommand,Response<int>>
        {
            private readonly IMerchantProductRepositoryAsync _MerchantProductRepository;
            private readonly IMapper _mapper;

            public CreateMerchantProductCommandHandler(IMerchantProductRepositoryAsync merchantProductRepository, IMapper mapper)
            {
                _MerchantProductRepository = merchantProductRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(CreateMerchantProductCommand request,CancellationToken cancellationToken)
            {
                var merchantproduct=_mapper.Map<MerchantProduct>(request);
                await _MerchantProductRepository.AddAsync(merchantproduct);
                return new Response<int>(merchantproduct.Id);


            }
        }
    }
}
