using Core_App.Interface.Repos;
using Core_Domain.Entities;
using DB_persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_persistence.Repos
{
    public class CategoryRepo : DefRepo<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
