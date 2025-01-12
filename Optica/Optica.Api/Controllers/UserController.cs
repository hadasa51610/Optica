using Microsoft.AspNetCore.Mvc;
using Optica.Core.Entites;
using Optica.Core.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        public UserController(IService<User> userService) => _userService = userService;

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> users = _userService.GetAll().ToList();
            return users == null ? NotFound() : users;
        }

        // GET api/<UserController>/5
        [HttpGet("{userId}")]
        public ActionResult<User> Get(string userId)
        {
            User user = _userService.GetById(userId);
            return user == null ? NotFound() : user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (user == null) return BadRequest("User data is required.");
            User u = _userService.Add(user);
            return u == null ? NotFound() : u;
        }

        // PUT api/<UserController>/5
        [HttpPut("{userId}")]
        public ActionResult<User> Put(string userId, [FromBody] User user)
        {
            if (userId == null) return BadRequest();
            if (_userService.GetById(userId) == null) return NotFound();
            User u = _userService.Update(userId, user);
            return u == null ? NotFound() : u;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{userId}")]
        public ActionResult<bool> Delete(string userId)
        {
            if (userId == null) return BadRequest();
            if (_userService.GetById(userId) == null) return NotFound();
            return _userService.Delete(userId);
        }
    }
}