namespace NextCBS.Bank.Module.Entities
{
    public abstract class AuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;
    }
}
