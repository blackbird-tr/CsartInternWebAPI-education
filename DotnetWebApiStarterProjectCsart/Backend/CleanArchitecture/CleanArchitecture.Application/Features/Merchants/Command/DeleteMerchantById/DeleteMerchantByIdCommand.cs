using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Merchants.Command.DeleteMerchantById
{
    public class DeleteMerchantByIdCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteMerchantByIdCommandHandler : IRequestHandler<DeleteMerchantByIdCommand, Response<int>>
        {
            private readonly IMerchantRepositoryAsync _merchantRepositoryAsync;
            public DeleteMerchantByIdCommandHandler(IMerchantRepositoryAsync merchantRepository)
            {
                _merchantRepositoryAsync = merchantRepository;
                
            }
            public async Task<Response<int>> Handle(DeleteMerchantByIdCommand command,CancellationToken cancellationToken)
            {
                var merchant = await _merchantRepositoryAsync.GetByIdAsync(command.Id);
                if (merchant == null) throw new ApiException("$Merchant Not Found");

                await _merchantRepositoryAsync.DeleteAsync(merchant);
                return new Response<int>(merchant.Id);
            }

        }
    }
}
