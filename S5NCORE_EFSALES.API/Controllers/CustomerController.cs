using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S5NCORE_EFSALES.CORE.DTOs;
using S5NCORE_EFSALES.CORE.Entities;
using S5NCORE_EFSALES.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        //public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer()
        {
            var customers = await _customerService.GetCustomers();

            //var customerList = new List<CustomerDTO>();
            //foreach (var item in customers)
            //{
            //    var customer = new CustomerDTO()
            //    {
            //        Id= item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        City = item.City,
            //        Phone = item.Phone
            //    };
            //    customerList.Add(customer);
            //}
            var customerList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customerList);
        }

        [HttpGet]
        [Route("CustomerById")]
        //[AllowAnonymous]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerService.GetCustomersById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpGet]
        [Route("CustomerOrdersById")]
        public async Task<IActionResult> CustomerOrdersById(int id)
        {
            var customer = await _customerService.GetCustomersById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerAndOrdersDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerService.Insert(customer);
            return Ok(result);
        }


        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(CustomerDTO customerDTO)
        {
            //if (id != customerDTO.Id)
            //    return NotFound();

            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerService.Update(customer);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }

    }
}
