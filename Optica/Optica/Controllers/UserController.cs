using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> users = userService.GetAll();
            if(users == null) return NotFound();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public ActionResult<User> Get(string userId)
        {
            User user = userService.GetByUserId(userId);
            if(user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            userService.PostUser(user);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{userId}")]
        public ActionResult Put(string userId, [FromBody] User user)
        {
            if(Get(userId)==null) return NotFound();
            userService.PutUser(userId,user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public ActionResult Delete(string userId)
        {
            if(Get(userId)==null) return NotFound();
            userService.DeleteUser(userId);
            return Ok();
        }
    }
}
