using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Viaticos.web.Data.Entities;

namespace Viaticos.web.Helpers
{

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        //  Task<SignInResult> LoginAsync(LoginViewModel model);        To Do
        Task LogoutAsync();
        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<SignInResult> ValidatePasswordAsync(User user, string password);
    }
}
