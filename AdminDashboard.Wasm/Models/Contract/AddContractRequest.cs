using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Wasm.Models.Contract
{
    public class AddContractRequest
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeSurname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CountryOfResidence { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CompanyWalletAddress { get; set; }

        [Required]
        public string EmployeeWalletAddress { get; set; }


        public ContractDetailsRequest ContractDetails { get; set; } = new();
    }
}
