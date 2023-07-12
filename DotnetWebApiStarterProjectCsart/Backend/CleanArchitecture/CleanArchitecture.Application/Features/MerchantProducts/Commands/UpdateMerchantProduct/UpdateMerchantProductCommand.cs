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

namespace CleanArchitecture.Core.Features.MerchantProducts.Commands.UpdateMerchantProduct
{
    public class UpdateMerchantProductCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int MerchantId  { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }
        
        public class UpdateMerchantProductCommandHandler : IRequestHandler<UpdateMerchantProductCommand, Response<int>>
        {
            private readonly IMerchantProductRepositoryAsync _MercahntProductRepository;
         

            public UpdateMerchantProductCommandHandler(IMerchantProductRepositoryAsync mercahntProductRepository, IMapper mapper)
            {
                _MercahntProductRepository = mercahntProductRepository;
            
            }
            public async Task<Response<int>> Handle(UpdateMerchantProductCommand command,CancellationToken cancellationToken)
            {
                var merchantproduct = await _MercahntProductRepository.GetByIdAsync(command.Id);
                if (merchantproduct == null) throw new EntityNotFoundException("merchantproduct", command.Id);
              merchantproduct.Price = command.Price;
                merchantproduct.ProductId = command.ProductId;
                merchantproduct.MerchantId = command.MerchantId;
                merchantproduct.IsEnabled = command.IsEnabled;
                await _MercahntProductRepository.UpdateAsync(merchantproduct);
                return new Response<int>(merchantproduct.Id);
               
            }
        }
    }
}
