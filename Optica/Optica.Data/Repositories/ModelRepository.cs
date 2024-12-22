using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        private readonly DataContext _context;
        public ModelRepository(DataContext dataContext)
        {
            _context=dataContext;
        }

        public List<Model> GetAll()
        {
            return _context.LoadModel();
        }

        public Model GetById(string modelId)
        {
            return _context.LoadModel().FirstOrDefault<Model>((m) => m.Id == modelId);
        }

        public bool Add(Model model)
        {
            List<Model> models = _context.LoadModel();
            Model model1 = models.FirstOrDefault<Model>((m) => m.Id == model.Id);
            if (model1 != null) return true;
            models.Add(model);
            return _context.SaveModel(models);
        }

        public bool Update(string modelId, Model model)
        {
            List<Model> models = _context.LoadModel();
            Model updateModel=models.FirstOrDefault(model => model.Id == modelId);
            if(updateModel == null) return false;
            updateModel.Color = model.Color;
            updateModel.Description = model.Description;
            updateModel.Scop = model.Scop;
            updateModel.Shape = model.Shape;
            updateModel.GlassSort = model.GlassSort;
            updateModel.GlassTarget = model.GlassTarget;
            return _context.SaveModel(models);
    }
        public bool Delete(string modelId)
        {
            List<Model> models = _context.LoadModel();
            Model model=models.FirstOrDefault<Model>((m) => m.Id == modelId);
            if (model == null) return false;
            models.Remove(model);
            return _context.SaveModel(models);
        }
    }
}