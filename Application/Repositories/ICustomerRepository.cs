using Domain.Entities;

namespace Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> GetByUsername(string username);
        Task<Customer> GetByEmail(string email);
        Task<bool> Create(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
    }
}
