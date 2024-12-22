using Optica.Core.Entites;
using Optica.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public List<Order> GetAll()
        {
            return _context.orders.ToList();
        }

        public Order GetById(string orderCode)
        {
            return _context.orders.FirstOrDefault<Order>((o) => o.OrderCode == orderCode);
        }

        public bool Update(string orderCode, Order order)
        {
            Order updateOrder = _context.orders.ToList().Find((o) => o.OrderCode == orderCode);
            if (updateOrder == null) return false;
            updateOrder.OrederDate = order.OrederDate;
            updateOrder.EPlaceOrder = order.EPlaceOrder;
            updateOrder.ItemsNumber = order.ItemsNumber;
            updateOrder.UserId = order.UserId;
            updateOrder.TotalPrice = order.TotalPrice;
            updateOrder.ReceptionNumber = order.ReceptionNumber;
            updateOrder.EPayment = order.EPayment;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(string orderCode)
        {
            Order order = _context.orders.ToList().Find((o) => o.OrderCode == orderCode);
            if(order == null) return false;
            _context.orders.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public bool Add(Order order)
        {
            Order order1 = _context.orders.ToList().Find((o) => o.OrderCode == order.OrderCode);
            if (order1 != null) return true;
            _context.orders.Add(order);
            _context.SaveChanges();
            return true;
        }
    }
}
