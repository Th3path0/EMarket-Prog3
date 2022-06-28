using Core_App.VMs.Category;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.VMs.Ads
{
    public class SaveAdVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del producto")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la categoria del producto")]
        public int CategoryId { get; set; }

        public List<CategoryVM> Categories { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        public int UserId { get; set; }
    }
}
