using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Wasm.Models.Employee
{
    public class AddEmployee
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CountryOfResidence { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WalletAddress { get; set; }

        [Required]
        public string PhoneNum { get; set; }
    }
}