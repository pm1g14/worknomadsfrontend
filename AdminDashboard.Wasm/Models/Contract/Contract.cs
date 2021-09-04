namespace AdminDashboard.Wasm.Models.Contract
{
    public class Contract
    {
        public int EmployeeId { get; set; }
        public string Address { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string BusinessPartner { get; set; }
        public string EmployeeWalletAddress { get; set; }
        public string CompanyWalletAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryOfResidence { get; set; }
        public string Email { get; set; }
        public decimal RemainingBalance { get; set; }
        public bool Active { get; set; }
        public ContractDetails ContractDetails { get; set; } = new();
    }
}