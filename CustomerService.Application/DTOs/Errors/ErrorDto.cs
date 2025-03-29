using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.DTOs.Errors
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string Details { get; set; }

        public ErrorDto(int statusCode, string message, string errorCode = null, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorCode = errorCode;
            Details = details;
        }
    }
}
