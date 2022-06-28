using Core_App.Associate;
using Core_App.Interface.Repos;
using Core_App.Interface.Services;
using Core_App.VMs.Product;
using Core_App.VMs.User;
using Core_Domain.Entities;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVM userViewModel;

        public ProductService(IProductRepo productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserVM>("user");
        }

        public async Task Update(SavePVM vm)
        {
            Product product = await _productRepository.GetByIdAsync(vm.Id);
            product.Id = vm.Id;
            product.Name = vm.Name;
            product.Price = vm.Price;
            product.ImageUrl = vm.ImageUrl;
            product.Description = vm.Description;
            product.CategoryId = vm.CategoryId;

            await _productRepository.UpdateAsync(product);
        }

        public async Task<SavePVM> Add(SavePVM vm)
        {
            Product product = new();
            product.Name = vm.Name;
            product.Price = vm.Price;
            product.ImageUrl = vm.ImageUrl;
            product.Description = vm.Description;
            product.CategoryId = vm.CategoryId;
            product.UserId = userViewModel.Id;

           product = await _productRepository.AddAsync(product);

            SavePVM productVm = new();

            productVm.Id = product.Id;
            productVm.Name = product.Name;
            productVm.Price = product.Price;
            productVm.ImageUrl = product.ImageUrl;
            productVm.Description = product.Description;
            productVm.CategoryId = product.CategoryId;

            return productVm;
        }

        public async Task Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<SavePVM> GetByIdSaveViewModel(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            SavePVM vm = new();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.Description = product.Description;
            vm.CategoryId = product.CategoryId;
            vm.Price = product.Price;
            vm.ImageUrl = product.ImageUrl;

            return vm;
        }

        public async Task<List<AdVM>> GetAllViewModel()
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            return productList.Where(product=> product.UserId == userViewModel.Id).Select(product => new ProductVM
            {
                Name = product.Name,
                Description = product.Description,
                Id= product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                CategoryId = product.Category.Id
            }).ToList();
        }

        public async Task<List<AdVM>> GetAllViewModelWithFilters(FilterPVM filters)
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            var listViewModels = productList.Where(product => product.UserId == userViewModel.Id).Select(product => new ProductVM
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                CategoryId = product.Category.Id
            }).ToList();

            if(filters.CategoryId != null)
            {
                listViewModels = listViewModels.Where(product => product.CategoryId == filters.CategoryId.Value).ToList();
            }

            return listViewModels;
        }

    }
}
