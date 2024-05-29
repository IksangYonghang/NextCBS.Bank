namespace NextCBS.Bank.Contracts.Models.Identity;

public class UserCreateModel
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public int ReferId { get; set; }
    public string? ClientCode { get; set; }
}