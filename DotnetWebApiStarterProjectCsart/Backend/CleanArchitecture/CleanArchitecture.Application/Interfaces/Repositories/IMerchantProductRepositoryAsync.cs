using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByProductId;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
   public interface IMerchantProductRepositoryAsync:IGenericRepositoryAsync<MerchantProduct>
    {
      
        Task<List<GetAllMerchantProductByMerchantIdViewModel>> GetMerhantProductByMerchantId(int MerchantId);
        Task<List<GetAllMerchantProductsByProduxtIdViewModel>> GetMerchantProductByProductId(int ProductId);
    }
}
