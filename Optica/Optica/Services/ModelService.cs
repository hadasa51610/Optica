using Microsoft.AspNetCore.Mvc;
using Optica.Entities;

namespace Optica.Services
{
    public class ModelService
    {
        public List<Model> GetAll() => DataContextManager.Data.Models;

        public Model GetById(string id) => DataContextManager.Data.Models.FirstOrDefault<Model>((model) => model.Id == id);

        public void PostModel(Model model) => DataContextManager.Data.Models.Add(model);

        public void PutModel(string id, Model model)
        {
            int index = DataContextManager.Data.Models.FindIndex((model) => model.Id == id);
            if (index != -1)
            {
                DataContextManager.Data.Models[index].Shape = model.Shape;
                DataContextManager.Data.Models[index].Scop=model.Scop;
                DataContextManager.Data.Models[index].Color = model.Color;
                DataContextManager.Data.Models[index].GlassSort=model.GlassSort;
                DataContextManager.Data.Models[index].GlassTarget=model.GlassTarget;
                DataContextManager.Data.Models[index].Description=model.Description;
            }
        }
        public void DeleteModel(string id) => DataContextManager.Data.Models.Remove(GetById(id));
    }
}
