using Domain.Entities;

namespace Application.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToList();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetByUsername(string username)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.UserName == username);
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> Create(Customer customer)
        {
            await _context.Customers.Add(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await GetById(id);
            if (customer == null) return false;
            
            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.customerId == id);
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await _context.Customers.AnyAsync(c => c.UserName == username);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }
    }
}