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
        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
        Task UpdateCustomer(CustomerDto customerDto);
        Task DeleteCustomer(int id);
    }
}
