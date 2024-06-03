using NextCBS.Bank.Module.Entities;
using System.Linq.Expressions;

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
