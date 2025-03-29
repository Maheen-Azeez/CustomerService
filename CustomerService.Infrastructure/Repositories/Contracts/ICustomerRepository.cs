using CustomerService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Task<Customer> CreateCustomer(Customer customer);
        public Task<Customer> UpdateCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(int id);
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> GetCustomerByName(string name);
        public Task<Customer> GetCustomerByEmail(string emailid);
        public Task<List<Customer>> GetPaginatedCustomers(int page, int size);
        public Task<List<Customer>> GetCustomers();

    }
}
