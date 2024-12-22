using Microsoft.AspNetCore.Mvc;
using Optica.Core.Entites;
using Optica.Core.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IService<Discount> _discountService;
        public DiscountController(IService<Discount> discount) => _discountService = discount;

        // GET: api/<DiscountController>
        [HttpGet]
        public ActionResult<List<Discount>> Get()
        {
            List<Discount> discounts = _discountService.GetAll();
            return discounts == null ? NotFound() : discounts;
        }

        // GET api/<DiscountController>/5
        [HttpGet("{discountId}")]
        public ActionResult<Discount> Get(string discountId)
        {
            Discount dis = _discountService.GetById(discountId);
            return dis == null ? NotFound() : dis;
        }

        // POST api/<DiscountController>
        [HttpPost]
        public ActionResult Post([FromBody] Discount dis)
        {
            if (dis == null) return BadRequest("Discount data is required.");
            if(_discountService.Add(dis)) return Ok();
            return StatusCode(500, "Failed to create the discount.");
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{discountId}")]
        public ActionResult Put(string discountId, [FromBody] Discount dis)
        {
            if (discountId == null) return BadRequest();
            if (_discountService.GetById(discountId) == null) return NotFound();
            if(_discountService.Update(discountId, dis)) return Ok();
            return StatusCode(500, "Failed to update the discount.");
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{discountId}")]
        public ActionResult Delete(string discountId)
        {
            if(discountId == null) return BadRequest();
            if (_discountService.GetById(discountId) == null) return NotFound();
            if(_discountService.Delete(discountId)) return Ok();
            return StatusCode(500, "Failed to delete the discount.");
        }
    }
}