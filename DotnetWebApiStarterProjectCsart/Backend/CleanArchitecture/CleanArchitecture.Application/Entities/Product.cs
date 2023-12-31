﻿using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        //Database Modified
        public virtual ICollection<MerchantProduct> MerchantProducts { get; set; }
    }
}
