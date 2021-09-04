namespace AdminDashboard.Wasm.Models.Contract
{
    public class ExecuteContract
    {
        public string ContractAddress { get; set; }
        public decimal Amount { get; set; }
        public string PaymentUnit { get; set; }
        public string RecipientWalletAddress { get; set; }
    }
}