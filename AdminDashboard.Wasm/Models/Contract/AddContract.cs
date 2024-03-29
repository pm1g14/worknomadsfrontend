﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Wasm.Models.Contract
{
    public class AddContract
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

        public ContractDetails ContractDetails { get; set; } = new();
    }
}