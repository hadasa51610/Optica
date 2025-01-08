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
        private readonly IRepository<Discount> _discountRepository;
        public DiscountService(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public IEnumerable<Discount> GetAll() => _discountRepository.GetAll();

        public Discount GetById(string discountId) => _discountRepository.GetById(discountId);

        public bool Update(string discountId, Discount discount) => _discountRepository.Update(discountId, discount);

        public bool Add(Discount discount) => _discountRepository.Add(discount);

        public bool Delete(string discountId) => _discountRepository.Delete(discountId);
    }
}
