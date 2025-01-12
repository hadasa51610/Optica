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
        public ActionResult<Check> Post([FromBody] Check check)
        {
            if (check == null) return BadRequest("Check data is required.");
            Check c = _checkService.Add(check);
            return c == null ? NotFound() : c;
        }

        // PUT api/<CheckController>/5
        [HttpPut("{checkId}")]
        public ActionResult<Check> Put(string checkId, [FromBody] Check check)
        {
            if (check == null) return BadRequest();
            if (_checkService.GetById(checkId) == null) return NotFound();
            Check c = _checkService.Update(checkId, check);
            return c == null ? NotFound() : c;
        }

        // DELETE api/<CheckController>/5
        [HttpDelete("{checkId}")]
        public ActionResult<bool> Delete(string checkId)
        {
            if (checkId == null) return BadRequest();
            if (_checkService.GetById(checkId) == null) return NotFound();
            return _checkService.Delete(checkId);
        }
    }
}