using NextCBS.Bank.Contracts;
using NextCBS.Bank.Module.Entities;
using NextCBS.Bank.Module.IRepositories;

namespace NextCBS.Bank.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserMeta _meta;

        public UserRepository(AppDbContext context, IUserMeta meta) : base(context)
        {
            _context = context;
            _meta = meta;
        }

        public Task<User?> GetAsync(int id)
         => GetFirstByConditionAsync(x => x.TenantId == _meta.ClientId && x.Id == id);
    }
}
