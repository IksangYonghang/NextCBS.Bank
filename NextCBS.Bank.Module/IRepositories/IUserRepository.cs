using System.Linq.Expressions;
using NextCBS.Bank.Module.Entities;

namespace NextCBS.Bank.Module.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetAsync(int id);
        Task<User> UpdateAsync(User entity);
        Task<User> InsertAsync(User entity);
        Task<ICollection<User>> GetByConditionAsync(Expression<Func<User, bool>> expression);
        Task DeleteAsync(User entity);
    }
}
