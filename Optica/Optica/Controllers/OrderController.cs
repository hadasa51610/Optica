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
        public OrderController() => orderService = new OrderService();

        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            List<Order> orders = orderService.GetAll();
            return orders == null ? NotFound() : orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{orderCode}")]
        public ActionResult<Order> Get(int orderCode)
        {
            Order order = orderService.GetByCode(orderCode);
            return order == null ? NotFound() : order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            orderService.PostOrder(order);
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{orderCode}")]
        public ActionResult Put(int orderCode, [FromBody] Order order)
        {
            if (orderService.GetByCode(orderCode) == null) return NotFound();
            orderService.PutOrder(orderCode, order);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{orderCode}")]
        public ActionResult Delete(int orderCode)
        {
            if (orderService.GetByCode(orderCode) == null) return NotFound();
            orderService.DeleteOrder(orderCode);
            return Ok();
        }
    }
}
