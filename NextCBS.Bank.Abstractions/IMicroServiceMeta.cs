namespace NextCBS.Bank.Abstractions;

public interface IMicroServiceMeta
{
    string ApiKey { get; }
    string StaticServiceUrl { get; }
    string IdentityServiceUrl { get; }
    string MemberServiceUrl { get; }

    string GetUrl(MicroService moduleName) =>
        moduleName switch
        {
            MicroService.Member => MemberServiceUrl,
            MicroService.Static => StaticServiceUrl,
            MicroService.Identity => IdentityServiceUrl,
            _ => "http://localhost"
        };
}

public enum MicroService
{
    Identity,
    Member,
    Static
}