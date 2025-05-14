using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<CustomerDto> GetCustomerByUsername(string username);
        Task<CustomerDto> GetCustomerByEmail(string email);
        Task<bool> CreateCustomer(CustomerCreateDto customerDto);
        Task<bool> UpdateCustomer(int id, CustomerUpdateDto customerDto);
        Task<bool> DeleteCustomer(int id);
        Task<bool> CustomerExists(int id);
    }
}
