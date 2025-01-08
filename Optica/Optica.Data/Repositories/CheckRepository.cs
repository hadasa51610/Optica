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

        public IEnumerable<Check> GetAll() => _context.checks.ToList();
        public Check GetById(string checkId) => _context.checks.FirstOrDefault(c=>c.CheckId==checkId);

        public bool Update(string checkId, Check check)
        {
            Check ch = GetById(checkId);
            if (ch == null) return false;

            ch.UserId = check.UserId;
            ch.Branch = check.Branch;
            ch.CheckDate = check.CheckDate;
            ch.NeedGlass = check.NeedGlass;
            ch.Number = check.Number;

            _context.SaveChanges();
            return true;
        }

        public bool Add(Check check)
        {
            if (GetById(check.CheckId) != null) return true;
            _context.checks.Add(check);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string checkId)
        {
            Check check = GetById(checkId);
            if (check == null) return false;
            _context.checks.Remove(check);
            _context.SaveChanges();
            return true;
        }
    }
}