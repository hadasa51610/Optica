using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        readonly DiscountService discount;
        public DiscountController() => discount = new DiscountService();

        // GET: api/<DiscountController>
        [HttpGet]
        public ActionResult<List<Discount>> Get()
        {
            List<Discount> discounts = discount.GetAll();
            return discounts == null ? NotFound() : discounts;
        }

        // GET api/<DiscountController>/5
        [HttpGet("{discountId}")]
        public ActionResult<Discount> Get(string discountId)
        {
            Discount dis = discount.GetByDiscountId(discountId);
            return dis == null ? NotFound() : dis;
        }

        // POST api/<DiscountController>
        [HttpPost]
        public ActionResult Post([FromBody] Discount dis)
        {
            discount.PostDiscount(dis);
            return Ok();
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{discountId}")]
        public ActionResult Put(string discountId, [FromBody] Discount dis)
        {
            if (discount.GetByDiscountId(discountId) == null) return NotFound();
            discount.PutDiscount(discountId, dis);
            return Ok();
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{discountId}")]
        public ActionResult Delete(string discountId)
        {
            if (discount.GetByDiscountId(discountId) == null) return NotFound();
            discount.DeleteDiscount(discountId);
            return Ok();
        }
    }
}
