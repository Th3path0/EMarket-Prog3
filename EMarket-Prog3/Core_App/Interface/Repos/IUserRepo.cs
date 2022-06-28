
using Core_App.VMs.User;
using Core_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_App.Interface.Repos
{
    public interface IUserRepo : IDefRepo<User>
    {
        Task<User> LoginAsync(LoginVM loginVm);
    }
}
