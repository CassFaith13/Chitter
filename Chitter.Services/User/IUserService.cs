using Chitter.Models.User;

namespace Chitter.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);

        Task<UserInfo> GetUserByIDAsync(int userID);
    }
}