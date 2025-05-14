using Application.DTOs;
using Application.Repositories;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.Select(MapToDto);
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetById(id);
            return customer != null ? MapToDto(customer) : null;
        }

        public async Task<CustomerDto> GetCustomerByUsername(string username)
        {
            var customer = await _customerRepository.GetByUsername(username);
            return customer != null ? MapToDto(customer) : null;
        }

        public async Task<CustomerDto> GetCustomerByEmail(string email)
        {
            var customer = await _customerRepository.GetByEmail(email);
            return customer != null ? MapToDto(customer) : null;
        }

        public async Task<bool> CreateCustomer(CustomerCreateDto customerDto)
        {
            // Kiểm tra username và email đã tồn tại chưa
            if (await _customerRepository.UsernameExists(customerDto.UserName))
                throw new Exception("Username đã tồn tại");

            if (await _customerRepository.EmailExists(customerDto.Email))
                throw new Exception("Email đã tồn tại");

            var customer = new Customer
            {
                UserName = customerDto.UserName,
                FullName = customerDto.FullName,
                Password = customerDto.Password, // need hashpass
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email,
                Address = customerDto.Address,
                DateOfBirth = customerDto.DateOfBirth,
                Role = customerDto.Role,
                PrioritizeScore = 0, 
                Status = UserStatus.Actived
            };

            return await _customerRepository.Create(customer);
        }

        public async Task<bool> UpdateCustomer(int id, CustomerUpdateDto customerDto)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
                return false;

            // Cập nhật thông tin
            customer.FullName = customerDto.FullName;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Email = customerDto.Email;
            customer.Address = customerDto.Address;
            customer.DateOfBirth = customerDto.DateOfBirth;
            customer.Role = customerDto.Role;
            customer.PrioritizeScore = customerDto.PrioritizeScore;
            customer.Status = customerDto.Status;

            return await _customerRepository.Update(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepository.Delete(id);
        }

        public async Task<bool> CustomerExists(int id)
        {
            return await _customerRepository.Exists(id);
        }

        private CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.customerId,
                UserName = customer.UserName,
                FullName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                Role = customer.Role,
                PrioritizeScore = customer.PrioritizeScore,
                Status = customer.Status
            };
        }
    }
}