
using Microsoft.AspNetCore.Http;
using NextCBS.Bank.Contracts;
using NextCBS.Bank.Contracts.Models;
using NextCBS.Bank.Contracts.Models.Identity;

namespace NextCBS.Bank.Intercom.Service;

public class IdentityIntercomService(
    IHttpContextAccessor httpContextAccessor,
    IMicroServiceMeta microServiceMeta,
    IUserMeta meta)
    : BaseIntercomService(MicroService.Identity, httpContextAccessor, microServiceMeta, meta)
{
    public async Task<IdentityUserModel> CreateUserAsync(UserCreateModel model)
    {
        const string endpoint = "/api/user";
        return await Post<IdentityUserModel, UserCreateModel>(endpoint, model);
    }

    public async Task<IdentityUserModel> GetUserAsync(string guid)
    {
        var endpoint = $"/api/user/guid/{guid}";
        return await Get<IdentityUserModel>(endpoint);
    }
    
    public async Task<bool> ChangePassword(IdentityPasswordChangeModel model)
    {
        const string endpoint = "/api/user/change-password";
        await Post(endpoint,model);
        return true;
    }

    public async Task UpdateUser(IdentityUserUpdateModel model)
    {
        const string endpoint = "/api/user";
        await Put(endpoint,model);
    }
    
    public async Task<bool> ToggleMfa(int userId)
    {
        var endpoint = $"/api/user/toggle-mfa/{userId}";
        var isEnabled = await Get<bool>(endpoint);
        return isEnabled;
    }

    public async Task UpdateUserDp(IdentityDpChangeModel model)
    {
        const string endpoint = $"/api/user/change-user-dp";
        await Post<bool,IdentityDpChangeModel>(endpoint,model);
    }
    
    public async Task<ProductSubsModel> GetSubscription(string returnUrl)
    {
        var query = new Dictionary<string, string> { { "returnUrl", returnUrl } };

        const string endpoint = $"/api/client/subs/3"; //3 is productId for meeting
        return await Get<ProductSubsModel>(endpoint, query);
    }

}