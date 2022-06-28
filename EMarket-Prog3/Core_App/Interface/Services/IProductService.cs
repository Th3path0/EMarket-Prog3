using Core_App.VMs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.Interface.Services { 

    public interface IProductService : IDefService<SaveAdVM, AdVM>
    {
        Task<List<AdVM>> GetAllViewModelWithFilters(FilterPVM filters);
    }
}

