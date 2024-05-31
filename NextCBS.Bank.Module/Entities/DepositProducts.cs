namespace NextCBS.Bank.Module.Entities
{
    public class DepositProducts : AuditableEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int BranchId { get; set; }
        public bool AllBranch { get; set; }
        public required string ProductName { get; set; }
        public required string ProductNameNp { get; set; }
        public string? Prefix { get; set; }
        public string? Sufix { get; set; }
        public decimal IntRate { get; set; }
        public bool LockIntRate { get; set; }
        public bool AutoAccount { get; set; } = true;
        public int AccNumberLength { get; set; }
        public bool IsTerm { get; set; } = false;
        public bool IsRecurring { get; set; }
        public int Installment { get; set; }
        public bool LockInstallment { get; set; }
        public int Duration { get; set; }
        public bool LockDuration { get; set; }
        public decimal MinBalance { get; set; }
        public decimal WithdrawalLimit { get; set; }
        public int IpfId { get; set; }
        public bool LockIpfId { get; set; }
        public int IntCalcTypeId { get; set; }
        public int TranGlId { get; set; }
        public int IntExpGlId { get; set; }
        public int IntPayableGlId { get; set; }
        public bool AllowCheque { get; set; }
        public decimal ChequeMinBalance { get; set; }
        public decimal ChequeCharge { get; set; }
        public bool AllowPreWithdrawal { get; set; }
        public decimal PreWithdrawCharge { get; set; }
        public decimal PreWithdrawRate { get; set; }
        public bool PostIntOnTermination { get; set; }
        public bool AllowOd { get; set; }
        public decimal OdRate { get; set; }
        public bool LockOdRate { get; set; }
        public decimal OdLimit { get; set; }
        public bool LockOdLimit { get; set; }
        public int OdIpfId { get; set; }
        public bool LockOdIpf { get; set; }
        public bool AllowStatement { get; set; }
        public int StatementFrequency { get; set; }
        public decimal StatementOverUseCharge { get; set; }
        public bool LockStatementOverUseCharge { get; set; }
        public bool Dormant { get; set; }
        public int DormancyDays { get; set; }
        public int OdGlId { get; set; }
        public decimal TaxRate { get; set; }
        public bool Status { get; set; }
        public bool LockMinBal { get; set; }
        public decimal InstallmentAmount { get; set; }
        public bool LockInstAmount { get; set; }
        public int IntFreqId { get; set; }
        public bool IsLongTerm { get; set; }
        public int LockInstFreq { get; set; }
        public bool IsCompulsory { get; set; }
        public bool IsMfProduct { get; set; }
        public bool IsChildSaving { get; set; }
        public int TaxGlId { get; set; }
        public bool IsChhumunuSaving { get; set; }
        public bool IsAgeDuration { get; set; }
        public int FineGlId { get; set; }
        public bool CompulsoryIntNominee { get; set; }
        public bool SyncOnApp { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public bool LockAllowCheque { get; set; }
        public decimal StatementChargeGlId { get; set; }
       
    }
}
