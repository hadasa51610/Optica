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
        private readonly IRepositoryManager _orderRepository;
        public OrderService(IRepositoryManager orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetAll() => _orderRepository._orders.GetFull();

        public Order GetById(string orderCode) => _orderRepository._orders.GetById(orderCode);

        public Order Update(string orderCode, Order order)
        {
            Order o = _orderRepository._orders.Update(orderCode, order);
            if (o != null) _orderRepository.Save();
            return o;
        }

        public bool Delete(string orderCode)
        {
            bool deleted = _orderRepository._orders.Delete(orderCode);
            if (deleted) _orderRepository.Save();
            return deleted;
        }

        public Order Add(Order order)
        {
            Order o = _orderRepository._orders.Add(order);
            if (o != null) _orderRepository.Save();
            return o;
        }
    }
}