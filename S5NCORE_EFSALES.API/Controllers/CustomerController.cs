using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(customers);
        }





    }
}
