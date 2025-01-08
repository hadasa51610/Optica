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

        public IEnumerable<Model> GetAll()=> _context.models.ToList();

        public Model GetById(string modelId)=> _context.models.FirstOrDefault(m=>m.ModelId==modelId);

        public bool Add(Model model)
        {
            if (GetById(model.ModelId) != null) return true;
            _context.models.Add(model);
            _context.SaveChanges();
            return true;
        }

        public bool Update(string modelId, Model model)
        {
            Model updateModel = GetById(modelId);
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
            Model model = GetById(modelId);
            if (model == null) return false;
            _context.models.Remove(model);
            _context.SaveChanges();
            return true;
        }
    }
}