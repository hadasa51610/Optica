using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly OrderService orderService;
        public OrderController()
        {
            orderService = new OrderService();
        }
        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            List<Order> orders = orderService.GetAll();
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{code}")]
        public ActionResult<Order> Get(int code)
        {
            Order order = orderService.GetByCode(code);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            orderService.PostOrder(order);
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{code}")]
        public ActionResult Put(int code, [FromBody] Order order)
        {
            if (orderService.GetByCode(code) == null)
                return NotFound();
            orderService.PutOrder(code, order);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{code}")]
        public ActionResult Delete(int code)
        {
            if (orderService.GetByCode(code) == null)
                return NotFound();
            orderService.DeleteOrder(code);
            return Ok();
        }
    }
}
