namespace NextCBS.Bank.Contracts.Models.Identity;

public class UserCreateModel
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public int ReferId { get; set; }
    public string? ClientCode { get; set; }
}