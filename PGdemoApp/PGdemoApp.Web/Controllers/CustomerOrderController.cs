using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGdemoApp.Core;
using PGdemoApp.data;

namespace PGdemoApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CustomerOrderController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customerDocs = await _db.CustomerDocs.ToListAsync();         
            return Ok(customerDocs);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDoc customerDoc)
        {
            try
            {
                //TODO ....validation, other processing ...etc

                //persistence
                _db.CustomerDocs.Add(customerDoc);
                await _db.SaveChangesAsync();


                return Ok(customerDoc);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var removeableDoc = await _db.CustomerDocs.FirstOrDefaultAsync(c => c.Id == id);
                if (removeableDoc != null)
                {
                    _db.CustomerDocs.Remove(removeableDoc);
                    await _db.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Summary()
        {
            try
            {
                var totalCustomer = await _db.CustomerDocs.CountAsync();

                var totalOrder = _db.CustomerDocs.ToList()
                    .SelectMany(d=> d.Customer.Orders)
                    .Sum(o=>o.Price);

                return Ok(new { 
                    customersCount = totalCustomer,
                    orderTotal = totalOrder
                });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
          
        }
    }
}
