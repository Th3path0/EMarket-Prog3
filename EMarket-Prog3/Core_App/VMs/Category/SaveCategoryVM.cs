using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.VMs.Category
{
    public class SaveCategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la categoria")]
        public string Name { get; set; }
        public string Description { get; set; }
 
    }
}
