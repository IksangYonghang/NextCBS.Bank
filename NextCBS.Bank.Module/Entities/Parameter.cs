using NextCBS.Bank.Module.Enum;

namespace NextCBS.Bank.Module.Entities
{
    public class Parameter : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public AccountType AccountType { get; set; }
        public required string ParameterName { get; set; }
        public required string ParameterValue { get; set; }
    }
}
