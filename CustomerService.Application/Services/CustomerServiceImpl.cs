using CustomerService.Application.DTOs.Requests;
using CustomerService.Application.DTOs.Responses;
using CustomerService.Application.Services.Contracts;
using CustomerService.Infrastructure.Repositories.Contracts;
using CustomerService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Services
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServiceImpl(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse<CustomerResponse>> CreateCustomer(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Gender = dto.Gender,
                Type = dto.Type,
                Mobile = dto.Mobile,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _customerRepository.CreateCustomer(customer);

            return new ApiResponse<CustomerResponse>(true, ResponseMessages.CreateSuccess, MapToDto(customer));
        }

        public async Task<ApiResponse<CustomerResponse>> UpdateCustomer(UpdateCustomerDto dto)
        {
            var customer = await _customerRepository.GetCustomerById(dto.Id);
            if (customer == null)
                return new ApiResponse<CustomerResponse>(false, ResponseMessages.NotFound);

            customer.Email = dto.Email;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Address = dto.Address;
            customer.Gender = dto.Gender;
            customer.Type = dto.Type;
            customer.Mobile = dto.Mobile;
            customer.UpdatedAt = DateTime.UtcNow;

            await _customerRepository.UpdateCustomer(customer);

            return new ApiResponse<CustomerResponse>(true, ResponseMessages.UpdateSuccess, MapToDto(customer));
        }

        public async Task<ApiResponse<bool>> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return new ApiResponse<bool>(false, ResponseMessages.NotFound);

            await _customerRepository.DeleteCustomer(customer.Id);
            return new ApiResponse<bool>(true, ResponseMessages.DeleteSuccess);
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return new ApiResponse<CustomerResponse>(false, ResponseMessages.NotFound);

            return new ApiResponse<CustomerResponse>(true, MapToDto(customer));
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomerByName(string name)
        {
            var customer = await _customerRepository.GetCustomerByName(name);
            if (customer == null)
                return new ApiResponse<CustomerResponse>(false, ResponseMessages.NotFound);

            return new ApiResponse<CustomerResponse>(true, MapToDto(customer));
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomerByEmail(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmail(email);
            if (customer == null)
                return new ApiResponse<CustomerResponse>(false, ResponseMessages.NotFound);

            return new ApiResponse<CustomerResponse>(true, MapToDto(customer));
        }

        public async Task<ApiResponse<List<CustomerResponse>>> GetPaginatedCustomers(int page, int size)
        {
            var customers = await _customerRepository.GetPaginatedCustomers(page, size);
            return new ApiResponse<List<CustomerResponse>>(true, customers.Select(MapToDto).ToList());
        }

        public async Task<ApiResponse<List<CustomerResponse>>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return new ApiResponse<List<CustomerResponse>>(true, customers.Select(MapToDto).ToList());
        }

        private static CustomerResponse MapToDto(Customer customer)
        {
            return new CustomerResponse
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Gender = customer.Gender,
                Type = customer.Type,
                Mobile = customer.Mobile,
            };
        }
    }
}
