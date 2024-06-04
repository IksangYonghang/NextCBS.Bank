using NextCBS.Bank.Abstractions.Enum;

namespace NextCBS.Bank.Module.Entities
{
    public class Parameter : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public ParameterType Type { get; set; }
        public required string ParameterName { get; set; }
        public required string ParameterValue { get; set; }
    }
}
