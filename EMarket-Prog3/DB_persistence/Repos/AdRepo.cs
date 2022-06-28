using DB_persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_persistence.Repos
{
    public class AdRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public AdRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
