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
        private readonly IRepositoryManager _checkRepository;
        public CheckService(IRepositoryManager checkRepository)
        {
            _checkRepository = checkRepository;
        }

        public IEnumerable<Check> GetAll() => _checkRepository._checks.GetFull();

        public Check GetById(string checkId) => _checkRepository._checks.GetById(checkId);

        public Check Update(string checkId, Check check)
        {
            Check c = _checkRepository._checks.Update(checkId, check);
            if (c != null) _checkRepository.Save();
            return c;
        }

        public Check Add(Check check)
        {
            Check c = _checkRepository._checks.Add(check);
            if (c != null) _checkRepository.Save();
            return c;
        }

        public bool Delete(string checkId)
        {
            bool deleted = _checkRepository._checks.Delete(checkId);
            if (deleted) _checkRepository.Save();
            return deleted;
        }
    }
}
