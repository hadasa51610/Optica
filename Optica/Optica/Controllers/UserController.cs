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
        public UserController(UserService user) => userService = user;

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> users = userService.GetAll();
            return users == null ? NotFound() : users;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public ActionResult<User> Get(string userId)
        {
            User user = userService.GetByUserId(userId);
            return user == null ? NotFound() : user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null) return BadRequest("User data is required.");
            if (userService.PostUser(user)) return Ok();
            return StatusCode(500, "Failed to create the user.");
        }

        // PUT api/<UserController>/5
        [HttpPut("{userId}")]
        public ActionResult Put(string userId, [FromBody] User user)
        {
            if (userId == null) return BadRequest();
            if (userService.GetByUserId(userId) == null) return NotFound();
            if(userService.PutUser(userId, user)) return Ok();
            return StatusCode(500, "Failed to update the user.");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public ActionResult Delete(string userId)
        {
            if(userId == null) return BadRequest();
            if (userService.GetByUserId(userId) == null) return NotFound();
            if (userService.DeleteUser(userId)) return Ok();
            return StatusCode(500, "Failed to delete the user.");
        }
    }
}
