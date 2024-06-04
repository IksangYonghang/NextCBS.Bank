using NextCBS.Bank.Abstractions;
using NextCBS.Bank.Abstractions.Models;
using NextCBS.Bank.Abstractions.Models.Identity;
using NextCBS.Bank.Intercom.Service;
using NextCBS.Bank.Module.Entities;
using NextCBS.Bank.Module.Exceptions;
using NextCBS.Bank.Module.IRepositories;

namespace Meeting.Module.Services;

public class UserService(
    IUserRepository userRepo,
    IUserPermissionRepository permissionRepo,
    IUserMeta meta,
    IdentityIntercomService identityService)
{
    public async Task<IEnumerable<UserModel>> GetUsersAsync()
    {
        var users = await userRepo.GetByConditionAsync(x => x.TenantId == meta.ClientId);
        return users.Select(ToUserModel);
    }

    public async Task<UserModel> UpsertUserAsync(UserModel model)
    {
        if (model.Id == 0)
        {
            var inserted = await userRepo.InsertAsync(ToUserEntity(model));
            try
            {
                var user = await identityService.CreateUserAsync(new UserCreateModel
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = model.Password,
                    FirstName = model.FullName,
                    LastName = "",
                    Phone = model.Contact,
                    ClientCode = meta.ClientCode,
                    ReferId = inserted.Id
                });

                inserted.Guid = user.Guid;
                await userRepo.UpdateAsync(inserted);

                return ToUserModel(inserted);
            }
            catch
            {
                await userRepo.DeleteAsync(inserted);
                throw;
            }
        }

        var item = await userRepo.GetAsync(model.Id);
        if (item == null) throw new UserNotFoundException();

        if (string.IsNullOrWhiteSpace(item.Guid))
        {
            var user = await identityService.GetUserAsync(model.Guid);

            item.Guid = user.Guid;
            await userRepo.UpdateAsync(item);
        }

        await identityService.UpdateUser(new IdentityUserUpdateModel
        {
            Email = model.Email,
            UserName = model.UserName,
            Id = model.Id,
            FirstName = model.FullName,
            LastName = "",
            Phone = model.Contact,
            MiddleName = "",
            Guid = item.Guid
        });

        var updated = await userRepo.UpdateAsync(ToUserEntity(model));
        return ToUserModel(updated);
    }

    public async Task<IdentityUserModel> GetUserAsync(string guid)
    {
        var res = await identityService.GetUserAsync(guid);
        res.Id = meta.UserId;

        return res;
    }

    private UserModel ToUserModel(User item)
    {
        return new UserModel
        {
            Email = item.Email,
            RoleName = item.RoleName,
            FullName = item.FullName,
            UserName = item.UserName,
            Id = item.Id,
            Password = "",
            Guid = item.Guid
        };
    }
    private User ToUserEntity(UserModel item)
    { 
       return new User
           {
               Email = item.Email,
               RoleName = item.RoleName,
               FullName = item.FullName,
               UserName = item.UserName,
               Id = item.Id,
               CreatedBy = meta.UserId,
               CreatedOn = DateTime.Now,
               TenantId = meta.ClientId,
               Guid = item.Guid
           };
    }
}