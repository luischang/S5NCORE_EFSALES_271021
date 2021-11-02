using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }

    }

    public class UserAuthCredentialsDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
