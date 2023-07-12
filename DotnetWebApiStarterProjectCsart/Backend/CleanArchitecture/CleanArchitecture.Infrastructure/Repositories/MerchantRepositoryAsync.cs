using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class MerchantRepositoryAsync : GenericRepositoryAsync<Merchant>, IMerchantRepositoryAsync
    {
         private readonly DbSet<Merchant> _merchants;

        public MerchantRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _merchants = dbContext.Set<Merchant>();
        }

         
    }
}
