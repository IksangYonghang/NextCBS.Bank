using NextCBS.Bank.Abstractions;
using NextCBS.Bank.Abstractions.Models;
using NextCBS.Bank.Module.Entities;
using NextCBS.Bank.Module.IRepositories;

namespace NextCBS.Bank.Data.Repositories
{
    public class UserPermissionReporitory : BaseRepository<UserPermission>, IUserPermissionRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserMeta _meta;

        public UserPermissionReporitory(AppDbContext context, IUserMeta meta) : base(context)
        {
            _context = context;
            _meta = meta;
        }

        public Task<IEnumerable<UserPermissionModel>> GetPermissionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task PostPermissionsAsync(List<UserPermissionModel> model)
        {
            throw new NotImplementedException();
        }
    }
}
