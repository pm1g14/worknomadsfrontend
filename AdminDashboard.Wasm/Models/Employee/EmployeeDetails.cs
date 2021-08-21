namespace AdminDashboard.Wasm.Models.Employee
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string WalletAddress { get; set; }
        public string Nationality { get; set; }
        public string CountryOfResidence { get; set; }
        public string PhoneNum { get; set; }
    }
}