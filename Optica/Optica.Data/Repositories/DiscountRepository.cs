using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class DiscountRepository : IRepository<Discount>
    {
        private readonly DataContext _context;
        public DiscountRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public List<Discount> GetAll() => _context.discounts.ToList();
        public Discount GetById(string discountId)
        {
            return _context.discounts.FirstOrDefault<Discount>(d => d.DiscountId == discountId);
        }
        public bool Update(string discountId, Discount discount)
        {
            Discount dis = _context.discounts.ToList().Find(d => d.DiscountId == discountId);
            if (dis == null) return false;
            dis.SickFundId = discount.SickFundId;
            dis.ESickFundName = discount.ESickFundName;
            dis.Rules = discount.Rules;
            dis.DiscountAmount = discount.DiscountAmount;
            dis.EAge = discount.EAge;
            _context.SaveChanges();
            return true;
        }
        public bool Add(Discount discount)
        {
            Discount dis = _context.discounts.ToList().FirstOrDefault<Discount>(d => d.DiscountId == discount.DiscountId);
            if (dis != null) return true;
            _context.discounts.Add(discount);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string discountId)
        {
            Discount discount = _context.discounts.ToList().FirstOrDefault<Discount>(d => d.DiscountId == discountId);
            if (discount == null) return false;
            _context.discounts.Remove(discount);
            _context.SaveChanges();
            return true;
        }
    }
}