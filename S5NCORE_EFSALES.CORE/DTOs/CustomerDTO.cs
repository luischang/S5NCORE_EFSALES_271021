using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.CORE.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }


    public class CustomerCityDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }


    public class CustomerCountryDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
    }

    public class CustomerPhoneDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
    }


    public class CustomerOrderDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<OrderNumberDTO> OrderNumber { get; set; }

    }

    public class CustomerPostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerAndOrdersDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public IEnumerable<OrderDTO> Order { get; set; }
    }


}
