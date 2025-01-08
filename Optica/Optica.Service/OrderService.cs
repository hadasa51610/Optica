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
    public class OrderService : IService<Order>
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(string orderCode)
        {
            return _orderRepository.GetById(orderCode);
        }

        public bool Update(string orderCode, Order order)
        {
            return _orderRepository.Update(orderCode, order);
        }

        public bool Delete(string orderCode)
        {
            return _orderRepository.Delete(orderCode);
        }

        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }
    }
}