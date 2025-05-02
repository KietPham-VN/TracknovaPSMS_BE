using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Suppliers
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PrioritizeScore { get; set; }
        public string Status { get; set; }
        public ICollection<ProductSupplier> productSuppliers { get; set; }
    }
}
