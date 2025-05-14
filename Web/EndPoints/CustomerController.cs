using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.EndPoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByUsername(string username)
        {
            var customer = await _customerService.GetCustomerByUsername(username);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmail(email);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customerDto)
        {
            try
            {
                var result = await _customerService.CreateCustomer(customerDto);
                if (result)
                    return CreatedAtAction(nameof(GetCustomerByUsername), new { username = customerDto.UserName }, customerDto);
                
                return BadRequest("Không thể tạo khách hàng");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerUpdateDto customerDto)
        {
            if (!await _customerService.CustomerExists(id))
                return NotFound();

            var result = await _customerService.UpdateCustomer(id, customerDto);
            if (result)
                return NoContent();

            return BadRequest("Không thể cập nhật khách hàng");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (!await _customerService.CustomerExists(id))
                return NotFound();

            var result = await _customerService.DeleteCustomer(id);
            if (result)
                return NoContent();

            return BadRequest("Không thể xóa khách hàng");
        }
    }
}