using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetAllMerchantProducts
{
    public class GetAllMerchantProductViewModel
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }

    }

}
