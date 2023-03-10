using CustomerWebApplication.Interfaces;
using CustomerWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApplication.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /*
        public IActionResult Index()
        {
            return View();
        }*/
       
        private ICustomersData _customerData;

        public CustomersController(ICustomersData CustomerData)
        {
            _customerData = CustomerData;
        }

        // GET: api/Customer
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCustomers()
        {
            var customers = _customerData.GetCustomers();
            return Ok(customers);
        }

        // GET: api/Customers
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateCustomers(Customers customers)
        {
            _customerData.CreateCustomer(customers);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
            HttpContext.Request.Path + "/" + customers.Id, customers);
        }
    }
}
