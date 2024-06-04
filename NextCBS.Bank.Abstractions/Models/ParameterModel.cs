using NextCBS.Bank.Abstractions.Enum;

namespace NextCBS.Bank.Abstractions.Models
{
    public class ParameterModel
    {
        public int Id { get; set; }
        public ParameterType Type { get; set; }
        public required string ParameterName { get; set; }
        public required string ParameterValue { get; set; }
    }
}
