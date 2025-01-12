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
            List<Model> models = _modelService.GetAll().ToList();
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
        public ActionResult<Model> Post([FromBody] Model model)
        {
            if (model == null) return BadRequest("Model data is required.");
            Model m = _modelService.Add(model);
            return m == null ? NotFound() : m;
        }

        // PUT api/<ModelController>/5
        [HttpPut("{modelId}")]
        public ActionResult<Model> Put(string modelId, [FromBody] Model model)
        {
            if (modelId == null) return BadRequest();
            if (_modelService.GetById(modelId) == null) return NotFound();
            Model m = _modelService.Update(modelId, model);
            return m == null ? NotFound() : m;
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{modelId}")]
        public ActionResult<bool> Delete(string modelId)
        {
            if (modelId == null) return BadRequest();
            if (_modelService.GetById(modelId) == null) return NotFound();
            return _modelService.Delete(modelId);
        }
    }
}