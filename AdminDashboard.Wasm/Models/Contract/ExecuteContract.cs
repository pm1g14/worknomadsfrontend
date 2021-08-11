namespace AdminDashboard.Wasm.Models.Contract
{
    public class ExecuteContract
    {
        public ExecuteContract(string contractAddress, string recipientWalletAddress)
        {
            ContractAddress = contractAddress;
            RecipientWalletAddress = recipientWalletAddress;
        }

        public string ContractAddress { get; set; }
        public decimal Amount { get; set; }
        public string PaymentUnit { get; set; }
        public string RecipientWalletAddress { get; set; }
    }
}