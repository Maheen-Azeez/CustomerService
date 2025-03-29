using CustomerService.Application.DTOs.Requests;
using CustomerService.Application.DTOs.Responses;
using CustomerService.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            //Validations has to be done -- Fluent Validation Installed for custom validation -- DataAnnotation is in use
            var result = await _customerService.CreateCustomer(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDto dto)
        {
            //Validations has to be done -- Fluent Validation Installed for custom validation -- DataAnnotation is in use
            var result = await _customerService.UpdateCustomer(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerById(id);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            var result = await _customerService.GetCustomerByName(name);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var result = await _customerService.GetCustomerByEmail(email);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedCustomers([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var result = await _customerService.GetPaginatedCustomers(page, size);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomers();
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}
