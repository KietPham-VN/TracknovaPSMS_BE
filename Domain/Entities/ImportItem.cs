using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class ImportItem
    {
        public int ImportItemId { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ImportId { get; set; }
        public int ProductId { get; set; }
    }
}
