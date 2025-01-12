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
    public class DiscountService : IService<Discount>
    {
        private readonly IRepositoryManager _discountRepository;
        public DiscountService(IRepositoryManager discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public IEnumerable<Discount> GetAll() => _discountRepository._discounts.GetFull();

        public Discount GetById(string discountId) => _discountRepository._discounts.GetById(discountId);

        public Discount Update(string discountId, Discount discount)
        {
            Discount d = _discountRepository._discounts.Update(discountId, discount);
            if (d != null) _discountRepository.Save();
            return d;
        }

        public Discount Add(Discount discount)
        {
            Discount d = _discountRepository._discounts.Add(discount);
            if (d != null) _discountRepository.Save();
            return d;
        }

        public bool Delete(string discountId)
        {
            bool deleted = _discountRepository._discounts.Delete(discountId);
            if (deleted) _discountRepository.Save();
            return deleted;
        }
    }
}
