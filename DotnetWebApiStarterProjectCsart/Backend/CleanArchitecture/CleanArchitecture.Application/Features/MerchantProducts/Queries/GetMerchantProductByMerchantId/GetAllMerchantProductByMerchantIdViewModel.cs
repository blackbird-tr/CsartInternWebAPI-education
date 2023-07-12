using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId
{
    public class GetAllMerchantProductByMerchantIdViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string MerchantName { get; set; }
    }
}
