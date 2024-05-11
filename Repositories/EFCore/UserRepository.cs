using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public User ChangePassword(User user)
        {
            Update(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            Delete(user);
            return user;
        }

        public async Task<PagedList<User>> GetAllUsersAsync(UserParameters parameters, bool trackChanges)
        {
            var users = await FindAll(trackChanges).OrderBy(u => u.UserId).Include(u => u.Roles).SearchUser(parameters.SearchTerm!).ToListAsync();
            return PagedList<User>.ToPagedList(users, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<User> GetUserAsync(int userId, bool trackChanges) =>
            await FindByCondition(u => u.UserId.Equals(userId), trackChanges).Include(u => u.Roles).SingleOrDefaultAsync();

        public User UpdateUser(User user)
        {
            Update(user);
            return user;
        }
    }
}
