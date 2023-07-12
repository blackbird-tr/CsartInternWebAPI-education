using AutoMapper;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetAllMerchantProducts
{
       
    public class GetAllMerchantProductQuery : IRequest<PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllMerchantProductQueryHandler : IRequestHandler<GetAllMerchantProductQuery, PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>>
    {
        private readonly IMerchantProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllMerchantProductQueryHandler(IMerchantProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>> Handle(GetAllMerchantProductQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllMerchantProductParameter>(request);
            var product = await _productRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<GetAllMerchantProductViewModel>>(product);
            return new PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
