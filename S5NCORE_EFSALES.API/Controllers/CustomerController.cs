using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S5NCORE_EFSALES.CORE.DTOs;
using S5NCORE_EFSALES.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer()
        {
            var customers = await _customerRepository.GetCustomers();

            var customerList = new List<CustomerCityDTO>();
            foreach (var item in customers)
            {
                var customer = new CustomerCityDTO()
                {
                    Id= item.Id,
                    //FirstName = item.FirstName,
                    LastName = item.LastName,
                    City = item.City,
                    //Phone = item.Phone
                };
                customerList.Add(customer);
            }
            return Ok(customerList);
        }





    }
}
