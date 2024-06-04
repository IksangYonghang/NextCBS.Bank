using System.Security.Claims;
using NextCBS.Bank.Abstractions;

namespace NextCBS.Bank.Api
{
   
        public class UserMeta : IUserMeta
        {
            public UserMeta(IHttpContextAccessor accessor)
            {
                var context = accessor.HttpContext;
                if (context != null)
                {
                    var userId = context.User?.FindFirstValue("uid");
                    var userGuid = context.User?.FindFirstValue("uGuid") ?? "";
                    var cCode = context.User?.FindFirstValue("cCode");
                    var cli = context.User?.FindFirstValue("cli");

                    if (userId == null)
                        return;

                    if (cCode != null) ClientCode = cCode;
                    if (!string.IsNullOrWhiteSpace(cli)) ClientId = int.Parse(cli);
                    if (!string.IsNullOrWhiteSpace(userGuid)) UserGuid = userGuid;

                    UserId = int.Parse(userId);
                    Locale = context.Request.Headers["locale"].ToString();
                }
            }
            public int UserId { get; set; }
            public string? UserGuid { get; set; }
            public string ClientCode { get; set; } = string.Empty;
            public int ClientId { get; set; }
            public string Locale { get; set; }
        }
    }

