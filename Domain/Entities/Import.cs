using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Import
    {
        public int ImportId { get; set; }
        public decimal TotalPayment { get; set; }
        public ImportStatusEnum Status { get; set; }
        public int SupplierId { get; set; }
        //public ICollection<ImportItem> ImportItems { get; set; }
    }
}
