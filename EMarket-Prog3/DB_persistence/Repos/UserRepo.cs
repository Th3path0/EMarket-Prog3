using Core_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_persistence.Repos
{
    class UserRepo
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        //navigation property
        public ICollection<Product> Products { get; set; }
    }
}
