using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Merchants.Command.UpdateMerchant
{
    public class UpdateMerchantCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public class UpdateMerchantCommandHandler:IRequestHandler<UpdateMerchantCommand,Response<int>> { 
        
        private readonly IMerchantRepositoryAsync _merchantRepository;

            public UpdateMerchantCommandHandler(IMerchantRepositoryAsync merchantRepository)
            {
                _merchantRepository = merchantRepository;
            }
            public async Task<Response<int>> Handle(UpdateMerchantCommand command,CancellationToken cancellationToken)
            {
                var merchant=await _merchantRepository.GetByIdAsync(command.Id);
                if(merchant == null) throw new EntityNotFoundException("merchant",command.Id);
                merchant.Email=command.Email;
                merchant.Name=command.Name; 
                await _merchantRepository.UpdateAsync(merchant);
                return new Response<int>(merchant.Id);

            }
        }
    }
}
