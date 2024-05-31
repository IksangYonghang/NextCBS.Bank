namespace NextCBS.Bank.Module.Entities
{
    public class UserRole : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string? RoleCode { get; set; }
        public required string RoleName { get; set; }
       
    }
}
