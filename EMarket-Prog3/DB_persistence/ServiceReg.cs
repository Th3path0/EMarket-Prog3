using Core_App.Interface.Repos;
using DB_persistence.Context;
using DB_persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace DB_persistence
{
    public static class ServiceReg
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //#region Contexts
            //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //    m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //}
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("ApplicationDb"));
            //}
            //#endregion

            #region Repositories
            services.AddTransient(typeof(IDefRepo<>), typeof(DefRepo<>));
            services.AddTransient<IProductRepo, IProductRepo>();
            services.AddTransient<ICategoryRepo, ICategoryRepo>();
            services.AddTransient<IUserRepo, IUserRepo>();
            #endregion
        }
    }
}
