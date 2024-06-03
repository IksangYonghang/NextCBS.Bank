using NextCBS.Bank.Module.Enum;

namespace NextCBS.Bank.Module.Models
{
    public class ParameterModel
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public required string ParameterName { get; set; }
        public required string ParameterValue { get; set; }
    }
}
