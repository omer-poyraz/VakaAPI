using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<PagedList<User>> GetAllUsersAsync(UserParameters parameters, bool trackChanges);
        Task<User> GetUserAsync(int userId, bool trackChanges);
        User UpdateUser(User user);
        User DeleteUser(User user);
        User ChangePassword(User user);
    }
}
