using Core_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Entities
{
   public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation property
        public ICollection<Product> Products { get; set; }
    }
}
