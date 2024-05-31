namespace NextCBS.Bank.Module.Entities
{
    public class UserPermission : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }       
        public bool CanView { get; set; } =true;
        public bool CanCreate { get; set; } =false ;
        public bool CanEdit { get; set; } = false;

    }
}
