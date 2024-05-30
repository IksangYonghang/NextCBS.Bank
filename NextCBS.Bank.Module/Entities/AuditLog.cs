namespace NextCBS.Bank.Module.Entities
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string? Tenant { get; set; }
        public required string Pkey { get; set; }
        public string? EntityType { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int ChangedBy { get; set; }
        public required string EntityState { get; set; }
        public string? NewValue { get; set; }
        public string? OldValue { get; set; }
    }
}
