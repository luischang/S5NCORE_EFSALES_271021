using Microsoft.EntityFrameworkCore;
using S5NCORE_EFSALES.CORE.Entities;
using S5NCORE_EFSALES.CORE.Interfaces;
using S5NCORE_EFSALES.INFRASTRUCTURE.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.INFRASTRUCTURE.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDBContext _context;

        public CustomerRepository(SalesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<bool> Insert(Customer customer)
        {
            _context.Customer.Add(customer);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Customer customer)
        {
            var customerNow = await _context.Customer.FindAsync(customer.Id);
            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customer.City = customer.City;
            customerNow.Country = customer.Country;
            customerNow.Phone = customer.Phone;

            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var customerNow = await _context.Customer.FindAsync(id);

            _context.Customer.Remove(customerNow);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }




    }
}
