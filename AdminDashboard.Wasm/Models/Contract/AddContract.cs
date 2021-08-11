using System;

namespace AdminDashboard.Wasm.Models.Contract
{
    public class AddContract
    {
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string CountryOfResidence { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeWalletAddress { get; set; }
        public string CompanyWalletAddress { get; set; }
        public DateTimeOffset ContractExpiry { get; set; }
        public string GrossSalary { get; set; }
        public string RemoteLocation { get; set; }
        public string PaymentTerm { get; set; }
    }
}