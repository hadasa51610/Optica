using Microsoft.AspNetCore.Mvc;
using Optica.Entities;
using Optica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        readonly ModelService Models;
        public ModelController() => Models = new ModelService();

        // GET: api/<ModelController>
        [HttpGet]
        public ActionResult<List<Model>> Get()
        {
            List<Model> models = Models.GetAll();
            return models == null ? NotFound() : models;
        }

        // GET api/<ModelController>/5
        [HttpGet("{modelId}")]
        public ActionResult<Model> Get(string modelId)
        {
            Model model = Models.GetById(modelId);
            return model == null ? NotFound() : model;
        }

        // POST api/<ModelController>
        [HttpPost]
        public ActionResult Post([FromBody] Model model)
        {
            Models.PostModel(model);
            return Ok();
        }

        // PUT api/<ModelController>/5
        [HttpPut("{modelId}")]
        public ActionResult Put(string modelId, [FromBody] Model model)
        {
            if (Models.GetById(modelId) == null) return NotFound();
            Models.PutModel(modelId, model);
            return Ok();
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{modelId}")]
        public ActionResult Delete(string modelId)
        {
            if (Models.GetById(modelId) == null) return NotFound();
            Models.DeleteModel(modelId);
            return Ok();
        }
    }
}
