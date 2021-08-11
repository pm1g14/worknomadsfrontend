namespace AdminDashboard.Wasm.Models.Contract
{
    public class ContractDetails
    {
        public string ContractExpiry { get; set; }
        public string GrossSalary { get; set; }
        public string RemoteLocation { get; set; }
        public int PaymentInstallments { get; set; }
        public string PaymentTerm { get; set; }
        public string BalanceUnit { get; set; }
    }
}