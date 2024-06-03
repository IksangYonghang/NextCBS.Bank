namespace NextCBS.Bank.Module.Models
{
    public class UserPermissionModel
    {
        public int Id { get; set; }       
        public int UserId { get; set; }
        public required string Title { get; set; }
        public bool CanView { get; set; } = true;
        public bool CanCreate { get; set; } = false;
        public bool CanEdit { get; set; } = false;
    }
}
