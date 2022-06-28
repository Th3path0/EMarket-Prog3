using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.Interface.Repos
{
    public interface IDefRepo<BaseEntity> where BaseEntity : class
    {
        Task<BaseEntity> AddAsync(BaseEntity entity);
        Task UpdateAsync(BaseEntity entity);
        Task DeleteAsync(BaseEntity entity);
        Task<List<BaseEntity>> GetAllAsync();
        Task<BaseEntity> GetByIdAsync(int id);
        Task<List<BaseEntity>> GetAllWithIncludeAsync(List<string> properties);
    }
}
