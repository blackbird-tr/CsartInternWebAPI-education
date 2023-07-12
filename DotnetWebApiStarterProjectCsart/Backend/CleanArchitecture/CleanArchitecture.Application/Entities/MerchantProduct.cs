using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class MerchantProduct:BaseEntity
    {
        public int MerchantId { get; set; }
        public int  ProductId   { get; set; }
        public decimal Price { get; set; }
        public DateTime LastExpDate { get; set; }
        public bool IsEnabled { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual Product Product { get; set; }

    }
}
