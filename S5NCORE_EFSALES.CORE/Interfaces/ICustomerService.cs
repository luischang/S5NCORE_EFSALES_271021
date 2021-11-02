using S5NCORE_EFSALES.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomersById(int id);
        Task<bool> Insert(Customer customer);
        Task<bool> Update(Customer customer);
    }
}