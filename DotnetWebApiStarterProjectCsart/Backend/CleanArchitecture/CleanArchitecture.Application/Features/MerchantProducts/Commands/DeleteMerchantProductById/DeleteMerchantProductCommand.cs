using AutoMapper;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.MerchantProducts.Commands.DeleteMerchantProductById
{
    public class DeleteMerchantProductCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteMerchantProductCommandHandler : IRequestHandler<DeleteMerchantProductCommand, Response<int>>
        {
           private readonly IMerchantProductRepositoryAsync merchantProductRepositoryAsync;
            private readonly IMapper mapper;

            public DeleteMerchantProductCommandHandler(IMerchantProductRepositoryAsync merchantProductRepositoryAsync, IMapper mapper)
            {
                this.merchantProductRepositoryAsync = merchantProductRepositoryAsync;
                this.mapper = mapper;
            }
            public async Task<Response<int>> Handle(DeleteMerchantProductCommand command,CancellationToken cancellationToken)
            {
                var merchantProduct=await merchantProductRepositoryAsync.GetByIdAsync(command.Id);
                if (merchantProduct == null) throw new ApiException($"MerchantProduct not Found");
                await merchantProductRepositoryAsync.DeleteAsync(merchantProduct);
                return new Response<int>(merchantProduct.Id);
            }
        }
    }
}
