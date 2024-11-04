using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        readonly DiscountService discount;
        public DiscountController()
        {
            discount = new DiscountService();
        }

        // GET: api/<DiscountController>
        [HttpGet]
        public ActionResult<List<Discount>> Get()
        {
            List<Discount> discounts = discount.GetAll();
            if (discounts == null) return NotFound();
            return Ok(discounts);
        }

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        public ActionResult<Discount> Get(string id)
        {
            Discount dis=discount.GetByDiscountId(id);
            if(dis==null) return NotFound();
            return Ok(dis);
        }

        // POST api/<DiscountController>
        [HttpPost]
        public ActionResult Post([FromBody] Discount dis)
        {
            discount.PostDiscount(dis);
            return Ok();
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Discount dis)
        {
            if(Get(id)==null) return NotFound();
            discount.PutDiscount(id,dis);
            return Ok();
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (Get(id) == null) return NotFound();
            discount.DeleteDiscount(id);
            return Ok();
        }
    }
}
