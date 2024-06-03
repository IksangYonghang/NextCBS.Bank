using NextCBS.Bank.Contracts;

namespace NextCBS.Bank.Api
{
    public class MicroServiceMeta(IConfiguration configuration) : IMicroServiceMeta
    {
        public string ApiKey { get; } = configuration.GetSection("MicroService:ApiKey").Value ?? "";
        public string StaticServiceUrl { get; } = configuration.GetSection("MicroService:Static")?.Value ?? "http://localhost";
        public string IdentityServiceUrl { get; } = configuration.GetSection("MicroService:Identity")?.Value ?? "http://localhost";
        public string MemberServiceUrl { get; } = configuration.GetSection("MicroService:Member")?.Value ?? "http://localhost";
        public string AdminServiceUrl { get; } = configuration.GetSection("MicroService:Admin")?.Value ?? "http://localhost";
    }
}
