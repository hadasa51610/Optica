using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        readonly CheckService checks;
        public CheckController()
        {
            checks=new CheckService();
        }

        // GET: api/<CheckController>
        [HttpGet]
        public ActionResult<List<Checks>> Get()
        {
            List<Checks> check = checks.GetAll();
            if(check==null)
                return NotFound();
            return Ok(check);
        }

        // GET api/<CheckController>/5
        [HttpGet("{code}")]
        public ActionResult<Checks> Get(int code)
        {
            Checks check = checks.GetById(code);
            if (check == null)
                return NotFound();
            return Ok(check);
        }

        // POST api/<CheckController>
        [HttpPost]
        public ActionResult Post([FromBody] Checks check)
        {
            checks.PostCheck(check);
            return Ok();
        }

        // PUT api/<CheckController>/5
        [HttpPut("{code}")]
        public ActionResult Put(int code, [FromBody] Checks check)
        {
            if(checks.GetById(code) == null)
                return NotFound();
            checks.PutCheck(code,check);
            return Ok();
        }

        // DELETE api/<CheckController>/5
        [HttpDelete("{code}")]
        public ActionResult Delete(int code)
        {
            if (checks.GetById(code) == null)
                return NotFound();
            checks.DeleteCheck(code);
            return Ok();
        }
    }
}
