using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public int ProductId { get; set; }
        public decimal PricingValue { get; set; }
        public string UnitType { get; set; }
        public int ExchangeQuantity { get; set; }
    }
}
