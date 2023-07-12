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

namespace CleanArchitecture.Core.Features.Merchants.Command.CreateMerchant
{
    public class CreateMerchantCommand:IRequest<Response<int>>
    {
        public String Name { get; set; }
        public String Email { get; set; }
    }
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, Response<int>>
    {
        private readonly IMerchantRepositoryAsync _merchantRepository;
        private readonly IMapper _mapper;
        public CreateMerchantCommandHandler(IMerchantRepositoryAsync merchantRepository,IMapper mapper)
        {
            _merchantRepository= merchantRepository;
            _mapper = mapper;
            
        }
        public async Task<Response<int>> Handle(CreateMerchantCommand request,CancellationToken cancellationToken)
        {
            var merchant = _mapper.Map<Merchant>(request);
            await _merchantRepository.AddAsync(merchant);
            return new Response<int>(merchant.Id);
        }

      
    }
}
