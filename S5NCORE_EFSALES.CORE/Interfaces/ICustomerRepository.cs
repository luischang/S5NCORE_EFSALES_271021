using S5NCORE_EFSALES.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> Delete(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<bool> Insert(Customer customer);
        Task<bool> Update(Customer customer);
    }
}