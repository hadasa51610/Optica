using Microsoft.AspNetCore.Mvc;
using Optica.Core.Entites;
using Optica.Core.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Optica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IService<Model> _modelService;
        public ModelController(IService<Model> service)
        {
            _modelService = service;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public ActionResult<List<Model>> Get()
        {
            List<Model> models = _modelService.GetAll();
            return models == null ? NotFound() : models;
        }

        // GET api/<ModelController>/5
        [HttpGet("{modelId}")]
        public ActionResult<Model> Get(string modelId)
        {
            Model model = _modelService.GetById(modelId);
            return model == null ? NotFound() : model;
        }

        // POST api/<ModelController>
        [HttpPost]
        public ActionResult Post([FromBody] Model model)
        {
            if (model == null) return BadRequest("Model data is required.");
            if (_modelService.Add(model)) return Ok();
            return StatusCode(500, "Failed to create the model.");
        }

        // PUT api/<ModelController>/5
        [HttpPut("{modelId}")]
        public ActionResult Put(string modelId, [FromBody] Model model)
        {
            if (modelId == null) return BadRequest();
            if (_modelService.GetById(modelId) == null) return NotFound();
            if (_modelService.Update(modelId, model)) return Ok();
            return StatusCode(500, "Failed to update the model.");
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{modelId}")]
        public ActionResult Delete(string modelId)
        {
            if (modelId == null) return BadRequest();
            if (_modelService.GetById(modelId) == null) return NotFound();
            if (_modelService.Delete(modelId)) return Ok();
            return StatusCode(500, "Failed to delete the model.");
        }
    }
}