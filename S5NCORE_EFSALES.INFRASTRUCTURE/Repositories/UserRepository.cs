using Microsoft.EntityFrameworkCore;
using S5NCORE_EFSALES.CORE.Entities;
using S5NCORE_EFSALES.CORE.Interfaces;
using S5NCORE_EFSALES.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.INFRASTRUCTURE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesDBContext _context;
        public UserRepository(SalesDBContext context)
        {
            _context = context;
        }


        public async Task<UserAuth> Authentication(string username, string password)
        {

            return await _context
                .UserAuth
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefaultAsync();
        }



    }
}
