﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Wasm.Models.Contract
{
    public class ContractDetails
    {
        [Obsolete]
        public string ContractExpiry2 { get; set; } // 2016-06-23T09:07:21Z
        public DateTime? ContractExpiry { get; set; } // 2016-06-23T09:07:21Z
        
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