using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalPayment { get; set; }
        public decimal? RemainPayment { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
        public string Status { get; set; }
    }
}
