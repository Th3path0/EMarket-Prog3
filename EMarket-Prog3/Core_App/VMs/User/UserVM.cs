using Core_App.VMs.Product;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.VMs.User
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
 
        public string Phone { get; set; }

        public ICollection<AdVM> Products { get; set; }
    }
}
