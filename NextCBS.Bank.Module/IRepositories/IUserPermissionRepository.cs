using NextCBS.Bank.Abstractions.Models;

namespace NextCBS.Bank.Module.IRepositories
{
    public interface IUserPermissionRepository
    {
        Task<IEnumerable<UserPermissionModel>> GetPermissionsAsync(int userId);
        Task PostPermissionsAsync(List<UserPermissionModel> model);
    }
}
