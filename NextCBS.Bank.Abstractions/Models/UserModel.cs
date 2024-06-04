namespace NextCBS.Bank.Abstractions.Models
{
    public class UserModel
    {
        public int Id { get; set; }       
        public required string RoleName { get; set; }
        public int BranchId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? Guid { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? Contact { get; set; }
        public bool Status { get; set; }
    }
}
