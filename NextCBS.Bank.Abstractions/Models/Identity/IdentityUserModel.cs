namespace NextCBS.Bank.Abstractions.Models.Identity;

public class IdentityUserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public bool IsTfaEnabled { get; set; }
    public string Guid { get; set; }
    public string ProfilePicture { get; set; }
}