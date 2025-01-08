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
        public IEnumerable<Discount> GetAll() => _context.discounts.ToList();

        public Discount GetById(string discountId) => _context.discounts.FirstOrDefault(d=>d.DiscountId==discountId);

        public bool Update(string discountId, Discount discount)
        {
            Discount dis = GetById(discountId);
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
            if (GetById(discount.DiscountId) != null) return true;
            _context.discounts.Add(discount);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string discountId)
        {
            Discount discount = GetById(discountId);
            if (discount == null) return false;
            _context.discounts.Remove(discount);
            _context.SaveChanges();
            return true;
        }
    }
}