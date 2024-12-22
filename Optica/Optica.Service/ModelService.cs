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
        private readonly IRepository<Model> _modelRepository;
        public ModelService(IRepository<Model> repository)
        {
            _modelRepository=repository;
        }
        public List<Model> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public Model GetById(string modelId)
        {
            return _modelRepository.GetById(modelId);
        }

        public bool Add(Model model)
        {
            return _modelRepository.Add(model);
        }

        public bool Update(string id, Model model)
        {
            return _modelRepository.Update(id, model);
        }

        public bool Delete(string modelId)
        {
            return _modelRepository.Delete(modelId);
        }
    }
}