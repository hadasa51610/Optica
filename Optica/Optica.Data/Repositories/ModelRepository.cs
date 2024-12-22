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
            _context = dataContext;
        }

        public List<Model> GetAll()
        {
            return _context.models.ToList();
        }

        public Model GetById(string modelId)
        {
            return _context.models.FirstOrDefault<Model>((m) => m.Id == modelId);
        }

        public bool Add(Model model)
        {
            Model model1 = _context.models.ToList().FirstOrDefault<Model>((m) => m.Id == model.Id);
            if (model1 != null) return true;
            _context.models.Add(model);
            _context.SaveChanges();
            return true;
        }

        public bool Update(string modelId, Model model)
        {
            Model updateModel = _context.models.ToList().FirstOrDefault(model => model.Id == modelId);
            if (updateModel == null) return false;
            updateModel.Color = model.Color;
            updateModel.Description = model.Description;
            updateModel.Scop = model.Scop;
            updateModel.Shape = model.Shape;
            updateModel.GlassSort = model.GlassSort;
            updateModel.GlassTarget = model.GlassTarget;
            _context.SaveChanges();
            return true;
        }
        public bool Delete(string modelId)
        {
            Model model = _context.models.ToList().FirstOrDefault<Model>((m) => m.Id == modelId);
            if (model == null) return false;
            _context.models.Remove(model);
            _context.SaveChanges();
            return true;
        }
    }
}