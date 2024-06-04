namespace NextCBS.Bank.Abstractions.Models.Identity;

public class IdentityPasswordChangeModel
{
    public int UserId { get; set; }
    public string New { get; set; }
}