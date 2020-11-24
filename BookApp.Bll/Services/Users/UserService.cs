using BookApp.Dto.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserService(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserEntity> GetUserEntity(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }
    }
}
