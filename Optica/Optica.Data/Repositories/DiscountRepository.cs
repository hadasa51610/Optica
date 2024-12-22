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
        public List<Discount> GetAll() => _context.LoadDiscount();
        public Discount GetById(string discountId)
        {
            return _context.LoadDiscount().FirstOrDefault<Discount>(d => d.DiscountId == discountId);
        }
        public bool Update(string discountId, Discount discount)
        {
            List<Discount> discounts = _context.LoadDiscount();
            Discount dis = discounts.Find(d => d.DiscountId == discountId);
            if (dis == null) return false;
            dis.SickFundId = discount.SickFundId;
            dis.ESickFundName = discount.ESickFundName;
            dis.Rules = discount.Rules;
            dis.DiscountAmount = discount.DiscountAmount;
            dis.EAge = discount.EAge;
            return (_context.SaveDiscount(discounts));
        }
        public bool Add(Discount discount)
        {
            List<Discount> discounts = _context.LoadDiscount();
            Discount dis = discounts.FirstOrDefault<Discount>(d => d.DiscountId == discount.DiscountId);
            if (dis != null) return true;
            discounts.Add(discount);
            return _context.SaveDiscount(discounts);
        }

        public bool Delete(string discountId)
        {
            List<Discount> discounts = _context.LoadDiscount();
            Discount discount = discounts.FirstOrDefault<Discount>(d => d.DiscountId == discountId);
            if (discount == null) return false;
            discounts.Remove(discount);
            return _context.SaveDiscount(discounts);
        }
    }
}