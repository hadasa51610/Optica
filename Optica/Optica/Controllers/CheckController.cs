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
        public CheckController() => checks = new CheckService();

        // GET: api/<CheckController>
        [HttpGet]
        public ActionResult<List<Checks>> Get()
        {
            List<Checks> checkList = checks.GetAll();
            return checkList == null ? NotFound() : checkList;
        }

        // GET api/<CheckController>/5
        [HttpGet("{checkCode}")]
        public ActionResult<Checks> Get(int checkCode)
        {
            Checks check = checks.GetByCode(checkCode);
            return check == null ? NotFound() : check;
        }

        // POST api/<CheckController>
        [HttpPost]
        public ActionResult Post([FromBody] Checks check)
        {
            checks.PostCheck(check);
            return Ok();
        }

        // PUT api/<CheckController>/5
        [HttpPut("{checkCode}")]
        public ActionResult Put(int checkCode, [FromBody] Checks check)
        {
            if (checks.GetByCode(checkCode) == null) return NotFound();
            checks.PutCheck(checkCode, check);
            return Ok();
        }

        // DELETE api/<CheckController>/5
        [HttpDelete("{checkCode}")]
        public ActionResult Delete(int checkCode)
        {
            if (checks.GetByCode(checkCode) == null) return NotFound();
            checks.DeleteCheck(checkCode);
            return Ok();
        }
    }
}
