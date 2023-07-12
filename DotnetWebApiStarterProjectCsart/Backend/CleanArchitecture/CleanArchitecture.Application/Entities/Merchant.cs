using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Merchant:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<MerchantProduct> MerchantProducts { get; set; }
    }
}
