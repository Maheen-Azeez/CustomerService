using CustomerService.Application.DTOs.Requests;
using CustomerService.Application.DTOs.Responses;
using CustomerService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Services.Contracts
{
    public interface ICustomerService
    {
        Task<ApiResponse<CustomerResponse>> CreateCustomer(CreateCustomerDto customer);
        Task<ApiResponse<CustomerResponse>> UpdateCustomer(UpdateCustomerDto customer);
        Task<ApiResponse<bool>> DeleteCustomer(int id);
        Task<ApiResponse<CustomerResponse>> GetCustomerById(int id);
        Task<ApiResponse<CustomerResponse>> GetCustomerByName(string name);
        Task<ApiResponse<CustomerResponse>> GetCustomerByEmail(string email);
        Task<ApiResponse<List<CustomerResponse>>> GetPaginatedCustomers(int page, int size);
        Task<ApiResponse<List<CustomerResponse>>> GetCustomers();
    }
}
