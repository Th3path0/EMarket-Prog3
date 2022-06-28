using Core_App.VMs.Category;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.Interface.Services
{
    public interface ICategoryService : IDefService<SaveCategoryVM, CategoryVM>
    {
      
    }
}
