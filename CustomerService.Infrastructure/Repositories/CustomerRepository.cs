using CustomerService.Infrastructure.Datas;
using CustomerService.Infrastructure.Repositories.Contracts;
using CustomerService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                customer.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            return customer;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.FirstName == name);
        }

        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<Customer>> GetPaginatedCustomers(int page, int size)
        {
            return await _context.Customers
                .OrderBy(c => c.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
