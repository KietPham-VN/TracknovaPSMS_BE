using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Repositories;
using Domain.Entities;

namespace Application.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer  = new Customer 
            {
                UserName = customerDto.UserName,
                PhoneNumber = customerDto.PhoneNumber
            };
            var result = await _customerRepository.Add(customer);
            customerDto.CustomerId = result.customerId;
            customerDto.UserName = result.UserName;
            customerDto.PhoneNumber = result.PhoneNumber;
            return customerDto;
        }

        public Task DeleteCustomer(int id)
        {
            return _customerRepository.Delete(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.Select(c => new CustomerDto
            {
                CustomerId = c.customerId,
                UserName = c.UserName,
                PhoneNumber = c.PhoneNumber
            });
        }

        public async Task<CustomerDto?> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerDto
            {
                CustomerId = customer.customerId,
                UserName = customer.UserName,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public async Task UpdateCustomer(CustomerDto customerDto)
        {
            var customer = await _customerRepository.GetById(customerDto.CustomerId);
            if (customer == null)
                return;
            customer.UserName = customerDto.UserName;
            customer.PhoneNumber = customerDto.PhoneNumber;
            await _customerRepository.Update(customer);
        }
    }
}
