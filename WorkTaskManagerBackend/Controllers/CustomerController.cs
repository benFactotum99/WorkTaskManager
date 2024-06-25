using Core.Services.Customers;
using Infrastructure.Persistence.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.Customers.Req;
using Shared.Entity.Customers.Res;

namespace WorkTaskManagerBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private CustomersService customersService;

        public CustomerController(CustomersService customersService)
        {
            this.customersService = customersService;
        }

        [HttpGet]
        public async Task<List<CustomerRes>> GetAll()
        {
            return (await customersService.GetAllAsync()).MapDto();
        }

        [HttpGet("{id}")]
        public async Task<CustomerRes> Get(int id)
        {
            var res = (await customersService.GetByIdAsync(id))?.MapDto();
            if (res == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status204NoContent;
            }
            return res;
        }

        [HttpPost]
        public async Task<CustomerRes> Create([FromBody] CustomerReq req)
        {
            Customer customer = req.MapDto();
            return (await customersService.Create(customer)).MapDto();
        }

        [HttpPut("{id}")]
        public async Task<CustomerRes> Update(int id, [FromBody] CustomerReq req)
        {
            Customer customer = req.MapDto((await customersService.GetByIdAsync(id)));
            return (await customersService.Update(customer)).MapDto();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await customersService.Delete(id);
        }
    }
}
