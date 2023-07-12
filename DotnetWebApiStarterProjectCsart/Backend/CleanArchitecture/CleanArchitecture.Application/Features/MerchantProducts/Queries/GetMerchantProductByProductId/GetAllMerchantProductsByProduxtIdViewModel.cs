using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByProductId
{
    public class GetAllMerchantProductsByProduxtIdViewModel
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string Decription { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string MerchantName { get; set; }
    }
}
