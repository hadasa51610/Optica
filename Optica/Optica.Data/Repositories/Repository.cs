using Microsoft.EntityFrameworkCore;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(string id)//its not work!!! how to do it without using the foreign key???
        {
            return _dbSet.Find(id);
            //var properties=typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //return _dbSet.FirstOrDefault<T>(e=>
            //    properties.Any(prop=>
             //       prop.GetValue(e).ToString().Equals(id, StringComparison.OrdinalIgnoreCase) == true));
        }

        public T Update(string id, T entity)
        {
            T entityToUpdate = GetById(id);
            if (entityToUpdate == null) return entityToUpdate;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.Name != "Id");
            foreach (var prop in properties)
            {
                var value = prop.GetValue(entity);
                if (value != null)
                {
                    prop.SetValue(entityToUpdate, value);
                }
            }
            return entityToUpdate;
        }

        public bool Delete(string id)
        {
            T entityToDelete= _dbSet.Find(id);
            if(entityToDelete == null) return false;
            _dbSet.Remove(entityToDelete);
            return true;
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
    }
}