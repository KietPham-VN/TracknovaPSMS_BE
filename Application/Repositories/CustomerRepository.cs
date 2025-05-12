using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppContext _context;
        public CustomerRepository(AppContext context)
        {
            _context = context;
        }
        public Task<Customer> Add(Customer customer)
        {
            // Simulate adding a customer to the database
            customer.customerId = new Random().Next(1, 1000); // Simulate auto-increment ID
            return Task.FromResult(customer);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            var customers = new List<Customer>
            {
                new Customer { customerId = 1, UserName = "john_doe", FullName = "John Doe", Email = "john@example.com", Status = UserStatus.Actived },
                new Customer { customerId = 2, UserName = "jane_doe", FullName = "Jane Doe", Email = "jane@example.com", Status = UserStatus.Inactived }
            };
            return Task.FromResult(customers.AsEnumerable());
        }

        public Task<Customer> GetById(int id)
        {
            var customer = new Customer
            {
                customerId = id,
                UserName = "john_doe",
                FullName = "John Doe",
                Email = "john@example.com",
                Status = UserStatus.Actived
            };
            return Task.FromResult(customer);
        }

        public Task Update(Customer customer)
        {
            return Task.CompletedTask;
        }
    }
}
