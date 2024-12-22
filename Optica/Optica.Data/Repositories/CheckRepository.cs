using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class CheckRepository : IRepository<Check>
    {
        private readonly DataContext _context;
        public CheckRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<Check> GetAll() => _context.LoadCheck();
        public Check GetById(string checkId)
        {
            return _context.LoadCheck().FirstOrDefault<Check>(c => c.CheckId == checkId);
        }

        public bool Update(string checkId, Check check)
        {
            List<Check> checks = _context.LoadCheck();
            Check ch = checks.Find(c => c.CheckId == checkId);
            if (ch == null) return false;
            ch.UserId = check.UserId;
            ch.CheckerId = check.CheckId;
            ch.Branch = check.Branch;
            ch.CheckDate = check.CheckDate;
            ch.NeedGlass = check.NeedGlass;
            ch.Number = check.Number;
            return (_context.SaveCheck(checks));
        }
        public bool Add(Check check)
        {
            List<Check> checks = _context.LoadCheck();
            Check ch = checks.FirstOrDefault<Check>(c => c.CheckId == check.CheckId);
            if (ch != null) return true;
            checks.Add(check);
            return _context.SaveCheck(checks);
        }
        public bool Delete(string checkId)
        {
            List<Check> checks = _context.LoadCheck();
            Check check = checks.FirstOrDefault<Check>(c => c.CheckId == checkId);
            if (check == null) return false;
            checks.Remove(check);
            return _context.SaveCheck(checks);
        }
    }
}