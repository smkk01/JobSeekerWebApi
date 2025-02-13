using CustomersWebApi.Data;
using CustomersWebApi.DTOs;
using CustomersWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
namespace CustomersWebApi.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CustomerController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet("GetCustomers")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var customers = await _appDbContext.Customer
                .Include(c => c.customerAddresses)
                .ToListAsync();
            return Ok(customers);
        }

        [HttpGet("GetCustomerById")]       
        public async Task<IActionResult> Get(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }            

            var customers = await _appDbContext.Customer
                .Include(c => c.customerAddresses).Where(c => c.Id == id).FirstOrDefaultAsync();
            
            if (customers == null)
            {
                return NotFound();
            }            
            
            var newCustomer = _mapper.Map<CustomerDTO>(customers);
            return Ok(newCustomer);
        }
        private Customer MapCustomerObject(CustomerDTO customer)
        {
            var result = new Customer();
            result.FirstName = customer.FirstName;
            result.LastName = customer.LastName;
            result.Phone = customer.Phone;
            result.customerAddresses = new List<CustomerAddress>();
            customer.customerAddresses.ForEach(c =>
            {
                var newAddress = new CustomerAddress();
                newAddress.City = c.City;
                newAddress.Country = c.Country;
                result.customerAddresses.Add(newAddress);
            });
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO customer)
        {
           // var newCustomer = MapCustomerObject(customer);
           if (!ModelState.IsValid)
           {
                return BadRequest();
           }
           var newCustomer = _mapper.Map<Customer>(customer);
           _appDbContext.Customer.Add(newCustomer);
           await _appDbContext.SaveChangesAsync();
           return Created($"/customer/{newCustomer.Id}", customer);
        }

        [HttpPut("UpdateCustomer")]        
        public async Task<IActionResult> Put(CustomerDTO customer)
        {
           // var newCustomer = MapCustomerObject(customer);
            List<CustomerAddress> addresses = _appDbContext.CustomerAddresses.Where(c=>c.CustomerId==customer.Id).ToList();
            _appDbContext.CustomerAddresses.RemoveRange(addresses);

            _appDbContext.SaveChangesAsync();

            var updateCustomer = _mapper.Map<Customer>(customer);
            _appDbContext.Customer.Update(updateCustomer);
            await _appDbContext.SaveChangesAsync();
            return Ok(updateCustomer);            

        }

        [HttpPut("DeleteCustomerById")]
        public async Task<IActionResult> Delete(int id)
        {
            // var newCustomer = MapCustomerObject(customer);
            var customerToDelete = await _appDbContext
                .Customer.Include(c => c.customerAddresses).Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            if (customerToDelete== null)
            {
                return NotFound();
            }

            _appDbContext.Customer.Remove(customerToDelete);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
