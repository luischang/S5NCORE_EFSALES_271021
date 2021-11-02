using S5NCORE_EFSALES.CORE.Entities;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.Services
{
    public interface IUserService
    {
        Task<UserAuth> ValidateUser(string username, string password);
    }
}