using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByProductId;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetAllMerchantProductByMerchantIdViewModel = CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId.GetAllMerchantProductByMerchantIdViewModel;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class MerchantProductRepositoryAsync : GenericRepositoryAsync<MerchantProduct>, IMerchantProductRepositoryAsync
    {
        private readonly DbSet<MerchantProduct> _merchants;

        public MerchantProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _merchants = dbContext.Set<MerchantProduct>();
        }

        async Task<List<GetAllMerchantProductsByProduxtIdViewModel>> IMerchantProductRepositoryAsync.GetMerchantProductByProductId(int ProductId)
        {
           return await _merchants.Where(entity => entity.ProductId == ProductId)
                 .Select(e => new GetAllMerchantProductsByProduxtIdViewModel
                 {
                     Id = e.Id,
                     MerchantId = e.MerchantId,
                     Price = e.Price,
                     Barcode = e.Product.Barcode,
                     Decription = e.Product.Description,
                     MerchantName = e.Merchant.Name
                 }).ToListAsync();
                 
        }

        async Task<List<GetAllMerchantProductByMerchantIdViewModel>> IMerchantProductRepositoryAsync.GetMerhantProductByMerchantId(int MerchantId)
        {
           return await _merchants
               .Where(e => e.MerchantId == MerchantId)
               .Select(e => new GetAllMerchantProductByMerchantIdViewModel
               {
                   Id = e.Id,
                   Price = e.Price,
                   ProductId = e.ProductId,
                   MerchantName = e.Merchant.Name,
                   ProductName=e.Product.Name     
               })
               .ToListAsync();
               

                
        }
    }
}