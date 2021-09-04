using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Wasm.Models.Contract
{
    public class ContractDetailsRequest
    {
        [Required]
        public string ContractExpiry { get; set; } // 2016-06-23T09:07:21Z

        [Required]
        public string GrossSalary { get; set; }

        [Required]
        public string RemoteLocation { get; set; }

        public int PaymentInstallments { get; set; }

        [Required]
        public string PaymentTerm { get; set; }

        [Required]
        public string BalanceUnit { get; set; }
    }
}
