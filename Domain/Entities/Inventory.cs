using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Inventory
    {
        public int InventoryId { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public int CurrentQuantity { get; set; }
        public int ProductId { get; set; }
    }
}
