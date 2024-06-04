namespace NextCBS.Bank.Abstractions;

public interface IUserMeta
{
    int UserId { get; set; }
    string? UserGuid { get; set; }
    string ClientCode { get; set; }
    int ClientId { get; set; }
    string Locale { get; set; }
}