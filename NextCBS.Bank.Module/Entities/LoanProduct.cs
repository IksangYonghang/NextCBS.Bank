namespace NextCBS.Bank.Module.Entities
{
    public class LoanProduct : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
        public bool AllBranch { get; set; }
        public required string ProductName { get; set; }
        public required string ProductNameNp { get; set; }
        public required string Prefix { get; set; }
        public required string Suffix { get; set; }
        public decimal IntRate { get; set; }
        public bool LockIntRate { get; set; }
        public decimal FineRate { get; set; }
        public bool LockFineRate { get; set; }
        public decimal PenaltyRate { get; set; }
        public bool LockPenaltyRate { get; set; }
        public decimal IdiscountRate { get; set; }
        public bool LockIdiscountRate { get; set; }
        public decimal PdiscountRate { get; set; }
        public bool LockPdiscountRate { get; set; }
        public int Duration { get; set; }
        public bool LockDuration { get; set; }
        public int YearDay { get; set; }
        public int Installment { get; set; }
        public bool LockInstallment { get; set; }
        public decimal InvestmentLimit { get; set; }
        public int GracePeriod { get; set; }
        public bool LockGracePeriod { get; set; }
        public int TranGlId { get; set; }
        public int IntGlId { get; set; }
        public int FineGlId { get; set; }
        public int PenaltyGlId { get; set; }
        public int IdiscountGlId { get; set; }
        public int PdiscountGlId { get; set; }
        public bool IsFlat { get; set; }
        public bool LockIsFlat { get; set; }
        public bool AutoAccount { get; set; } = true;
        public int AccNumberLength { get; set; }
        public int CollectionGlId { get; set; }
        public bool Status { get; set; }
        public int IntReceivableGlId { get; set; }
        public int IntSuspenseGlId { get; set; }
        public bool IsLoanAgainstFd { get; set; }
        public bool ApplicationCompulsory { get; set; }
        public int ProductTypeId { get; set; }
        public decimal IncreaseRate { get; set; }
        public bool IsMfProduct { get; set; }
        public bool SyncOnApp { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    

    }
}
