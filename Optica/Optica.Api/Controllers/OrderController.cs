using Microsoft.AspNetCore.Mvc;
using Optica.Core.Entites;
using Optica.Core.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<Order> _orderService;
        public OrderController(IService<Order> orderService)
        {
            _orderService=orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            List<Order> orders = _orderService.GetAll();
            return orders == null ? NotFound() : orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{orderCode}")]
        public ActionResult<Order> Get(string orderCode)
        {
            Order order = _orderService.GetById(orderCode);
            return order == null ? NotFound() : order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            if (order == null) return BadRequest("Order data is required.");
            if (_orderService.Add(order)) return Ok();
            return StatusCode(500, "Failed to create the order.");
        }

        // PUT api/<OrderController>/5
        [HttpPut("{orderCode}")]
        public ActionResult Put(string orderCode, [FromBody] Order order)
        {
            if (orderCode == null) return BadRequest();
            if (_orderService.GetById(orderCode) == null) return NotFound();
            if (_orderService.Update(orderCode, order)) return Ok();
            return StatusCode(500, "Failed to update the order.");
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{orderCode}")]
        public ActionResult Delete(string orderCode)
        {
            if (orderCode == null) return BadRequest();
            if (_orderService.GetById(orderCode) == null) return NotFound();
            if (_orderService.Delete(orderCode)) return Ok();
            return StatusCode(500, "Failed to delete the order.");
        }
    }
}