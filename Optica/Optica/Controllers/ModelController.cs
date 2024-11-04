using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;
//using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        readonly ModelService ModelService;
        public ModelController()
        {
            ModelService = new ModelService();
        }
        // GET: api/<ModelController>
        [HttpGet]
        public ActionResult<List<Model>> Get()
        {
            List<Model> models = ModelService.GetAll();
            if (models == null) return NotFound();
            return Ok(models);
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public ActionResult<Model> Get(string id)
        {
            Model model = ModelService.GetById(id);
            if (model == null) return NotFound();
            return Ok(model);
        }

        // POST api/<ModelController>
        [HttpPost]
        public void Post([FromBody] Model model)
        {
            ModelService.PostModel(model);
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Model model)
        {
            Model m = ModelService.GetById(id);
            if (m == null) return NotFound();
            ModelService.PutModel(id, model);
            return Ok();
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            Model m = ModelService.GetById(id);
            if (m == null) return NotFound();
            ModelService.DeleteModel(id);
            return Ok();
        }
    }
}
