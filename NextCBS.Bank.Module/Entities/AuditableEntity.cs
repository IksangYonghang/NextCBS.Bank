namespace NextCBS.Bank.Module.Entities
{
    public class AuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;
    }
}
