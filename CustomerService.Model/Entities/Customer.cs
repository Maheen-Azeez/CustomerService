using CustomerService.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Model.Entities
{
    public class Customer : BaseModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public Gender Gender { get; set; }
        public CustomerType Type { get; set; }
        [Phone]
        public string? Mobile {  get; set; }
    }
}
