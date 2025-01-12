using Optica.Core.Entites;
using Optica.Core.IRepositories;
using Optica.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Service
{
    public class ModelService : IService<Model>
    {
        private readonly IRepositoryManager _modelRepository;
        public ModelService(IRepositoryManager repository)
        {
            _modelRepository = repository;
        }
        public IEnumerable<Model> GetAll() => _modelRepository._models.GetFull();

        public Model GetById(string modelId) => _modelRepository._models.GetById(modelId);

        public Model Add(Model model)
        {
            Model m = _modelRepository._models.Add(model);
            if (m != null) _modelRepository.Save();
            return m;
        }

        public Model Update(string id, Model model)
        {
            Model m = _modelRepository._models.Update(id, model);
            if (m != null) _modelRepository.Save();
            return m;
        }

        public bool Delete(string modelId)
        {
            bool deleted = _modelRepository._models.Delete(modelId);
            if (deleted) _modelRepository.Save();
            return deleted;
        }
    }
}