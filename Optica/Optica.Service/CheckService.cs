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
    public class CheckService : IService<Check>
    {
        private readonly IRepository<Check> _checkRepository;
        public CheckService(IRepository<Check> checkRepository)
        {
            _checkRepository = checkRepository;
        }

        public List<Check> GetAll() => _checkRepository.GetAll();

        public Check GetById(string checkId) => _checkRepository.GetById(checkId);

        public bool Update(string checkId, Check check) => _checkRepository.Update(checkId, check);

        public bool Add(Check check) => _checkRepository.Add(check);

        public bool Delete(string checkId) => _checkRepository.Delete(checkId);
    }
}
