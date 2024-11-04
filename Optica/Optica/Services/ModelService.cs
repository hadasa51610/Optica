using Microsoft.AspNetCore.Mvc;
using Optica.Entities;

namespace Optica.Services
{
    public class ModelService
    {
        static List<Model> Models { get;}
        public ModelService() { }
        static ModelService()
        {
            Models=new List<Model>();
            Models.Add(new Model(1,"111","red","thin",2.5,"circle",Sort.INCREASE,Target.BABY));
            Models.Add(new Model(2,"222","blue","thin",3.5,"circle",Sort.INCREASE,Target.OLDER));
        }
        public List<Model> GetAll()
        {
            return Models;
        }
        public Model GetById(string id)
        {
            foreach (var model in Models)
            {
                if (model.Id == id)
                    return model;
            }
            return null;
        }
        public void PostModel(Model model)
        {
            Models.Add(model);
        }
        public void PutModel(string id, Model model)
        {
            for (int i = 0; i < Models.Count(); i++)
            {
                if (Models[i].Id == id)
                {
                    Models[i] = model;
                    return;
                }
            }
        }
        public void DeleteModel(string id)
        {
            foreach (var model in Models)
            {
                if (model.Id == id)
                {
                    Models.Remove(model);
                    return;
                }
            }
        }
    }
}
