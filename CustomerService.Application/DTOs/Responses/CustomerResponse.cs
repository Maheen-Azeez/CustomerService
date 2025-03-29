using CustomerService.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.DTOs.Responses
{
    public class CustomerResponse
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public Gender Gender { get; set; }
        public CustomerType Type { get; set; }
        public string? Mobile { get; set; }
    }
}
