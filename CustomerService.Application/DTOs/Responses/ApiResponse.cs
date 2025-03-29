using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.DTOs.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public ApiResponse(bool success, T? data = default)
        {
            Success = success;
            Data = data;
        }
    }
}
