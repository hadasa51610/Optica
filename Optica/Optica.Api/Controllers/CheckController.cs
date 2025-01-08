using Microsoft.AspNetCore.Mvc;
using Optica.Core.Entites;
using Optica.Core.IServices;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly IService<Check> _checkService;
        public CheckController(IService<Check> checkService) => _checkService = checkService;

        // GET: api/<CheckController>
        [HttpGet]
        public ActionResult<IEnumerable<Check>> Get()
        {
            List<Check> checkList = _checkService.GetAll().ToList();
            return checkList == null ? NotFound() : checkList;
        }

        // GET api/<CheckController>/5
        [HttpGet("{checkId}")]
        public ActionResult<Check> Get(string checkId)
        {
            Check check = _checkService.GetById(checkId);
            return check == null ? NotFound() : check;
        }

        // POST api/<CheckController>
        [HttpPost]
        public ActionResult Post([FromBody] Check check)
        {
            if (check == null) return BadRequest("Check data is required.");
            if(_checkService.Add(check)) return Ok();
            return StatusCode(500, "Failed to create the check.");
        }

        // PUT api/<CheckController>/5
        [HttpPut("{checkId}")]
        public ActionResult Put(string checkId, [FromBody] Check check)
        {
            if(check == null) return BadRequest();
            if (_checkService.GetById(checkId) == null) return NotFound();
            if (_checkService.Update(checkId, check)) return Ok();
            return StatusCode(500, "Failed to update the check.");
        }

        // DELETE api/<CheckController>/5
        [HttpDelete("{checkId}")]
        public ActionResult Delete(string checkId)
        {
            if(checkId == null) return BadRequest();
            if (_checkService.GetById(checkId) == null) return NotFound();
            if(_checkService.Delete(checkId)) return Ok();
            return StatusCode(500, "Failed to delete the check.");
        }
    }
}