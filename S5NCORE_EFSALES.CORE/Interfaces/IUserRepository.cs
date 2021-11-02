using S5NCORE_EFSALES.CORE.Entities;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.Interfaces
{
    public interface IUserRepository
    {
        Task<UserAuth> Authentication(string username, string password);
    }
}