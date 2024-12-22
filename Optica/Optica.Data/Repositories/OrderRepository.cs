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
            return _context.LoadOrder();
        }

        public Order GetById(string orderCode)
        {
            return _context.LoadOrder().FirstOrDefault<Order>((o) => o.Code == orderCode);
        }

        public bool Update(string orderCode, Order order)
        {
            List<Order> orders = _context.LoadOrder();
            Order findOrder = orders.Find((o) => o.Code == orderCode);
            if (findOrder == null) return false;
            Order updateOrder = findOrder;
            orders.Remove(findOrder);
            updateOrder.OrederDate = order.OrederDate;
            updateOrder.EPlaceOrder = order.EPlaceOrder;
            updateOrder.ItemsNumber = order.ItemsNumber;
            updateOrder.UserId = order.UserId;
            updateOrder.TotalPrice = order.TotalPrice;
            updateOrder.ReceptionNumber = order.ReceptionNumber;
            updateOrder.EPayment = order.EPayment;
            return (_context.SaveOrders(orders));
        }

        public bool Delete(string orderCode)
        {
            List<Order> orders = _context.LoadOrder();
            orders.Remove(orders.Find((o) => o.Code == orderCode));
            return _context.SaveOrders(orders);
        }

        public bool Add(Order order)
        {
            List<Order> orders = _context.LoadOrder();
            Order order1 = orders.Find((o) => o.Code == order.Code);
            if (order1 != null) return true;
            orders.Add(order);
            return (_context.SaveOrders(orders));
        }
    }
}
