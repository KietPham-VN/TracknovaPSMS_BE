using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PrioritizeScore { get; set; }
        //public CategoryStatusEnum Status { get; set; }
        //public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}