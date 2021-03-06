using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Domain.Entities
{
    public class Ad
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }
        public int Id { get; set; }

    }
}
