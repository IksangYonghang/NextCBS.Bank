namespace NextCBS.Bank.Contracts;

public interface IUserMeta
{
    int UserId { get; set; }
    string? UserGuid { get; set; }
    string ClientCode { get; set; }
    int ClientId { get; set; }
    string Locale { get; set; }
}