using Core_App.Associate;
using Core_App.Interface.Repos;
using Core_App.Interface.Services;
using Core_App.VMs.Category;
using Core_App.VMs.User;
using Core_Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVM userViewModel;

        public CategoryService(ICategoryRepo categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserVM>("user");
        }

        public async Task Update(SaveCategoryVM vm)
        {
            Category category = await _categoryRepository.GetByIdAsync(vm.Id);
            category.Id = vm.Id;
            category.Name = vm.Name;
            category.Description = vm.Description;           

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task<SaveCategoryVM> Add(SaveCategoryVM vm)
        {
            Category category = new();
            category.Name = vm.Name;          
            category.Description = vm.Description;           

            category = await _categoryRepository.AddAsync(category);

            SaveCategoryVM categoryVm = new();

            categoryVm.Id = category.Id;
            categoryVm.Name = category.Name;
            categoryVm.Description = category.Description;        

            return categoryVm;
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<SaveCategoryVM> GetByIdSaveViewModel(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            SaveCategoryVM vm = new();
            vm.Id = category.Id;
            vm.Name = category.Name;
            vm.Description = category.Description;    

            return vm;
        }

        public async Task<List<CategoryVM>> GetAllViewModel()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Products"});

            return categoryList.Select(category => new CategoryVM
            {
                Name = category.Name,
                Description = category.Description,
                Id= category.Id,
                ProductsQuantity = category.Products.Where(product=> product.UserId == userViewModel.Id).Count()
            }).ToList();
        }

    }
}
