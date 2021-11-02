using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer()
        {
            var customers = await _customerRepository.GetCustomers();

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
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.Insert(customer);
            return Ok(result);
        }


        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(int id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.Id)
                return NotFound();

            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerRepository.Update(customer);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }

    }
}
