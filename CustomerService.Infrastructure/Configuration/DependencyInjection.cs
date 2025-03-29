using CustomerService.Infrastructure.Datas;
using CustomerService.Infrastructure.Repositories;
using CustomerService.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                // Register repositories
                services.AddScoped<ICustomerRepository, CustomerRepository>();

                return services;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
