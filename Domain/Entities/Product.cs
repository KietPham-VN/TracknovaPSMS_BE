using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ScanCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public ushort PrioritizeScore { get; set; }
        public string Status { get; set; }
    }
}
