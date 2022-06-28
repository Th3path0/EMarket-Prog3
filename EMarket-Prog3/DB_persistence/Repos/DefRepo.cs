using Core_App.Interface.Repos;
using Core_Domain.Entity;
using DB_persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_persistence.Repos
{
    public class DefRepo<BaseEntity> : IDefRepo<BaseEntity> where BaseEntity : class
    {
        private ApplicationDbContext dbContext;

        public DefRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<BaseEntity> AddAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<BaseEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BaseEntity>> GetAllWithIncludeAsync(List<string> properties)
        {
            throw new NotImplementedException();
        }

        public Task<BaseEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
