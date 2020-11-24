using BookApp.Dto.Entities;
using System.Threading.Tasks;

namespace BookApp.Bll.Services.Users
{
    public interface IUserService
    {
        Task<UserEntity> GetUserEntity(string name);
    }
}
