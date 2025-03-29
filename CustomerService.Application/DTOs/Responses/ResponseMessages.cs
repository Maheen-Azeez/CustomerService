using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.DTOs.Responses
{
    public static class ResponseMessages
    {
        public const string CreateSuccess = "Customer created successfully.";
        public const string CreateFailure = "Failed to create customer.";

        public const string UpdateSuccess = "Customer updated successfully.";
        public const string UpdateFailure = "Failed to update customer.";

        public const string DeleteSuccess = "Customer deleted successfully.";
        public const string DeleteFailure = "Failed to delete customer.";

        public const string NotFound = "Customer not found.";
    }
}
