
using Core_App.VMs.User;
using System.Threading.Tasks;

namespace Core_App.Interface.Services
{
    public interface IUserService : IDefService<SaveUserVM, UserVM>
    {
        Task<UserVM> Login(LoginVM vm);
    }
}
