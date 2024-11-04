using Optica.Entities;

namespace Optica.Services
{
    public class OrderService
    {
        static List<Order> Orders { get; }
        public OrderService() { }
        static OrderService()
        {
            Orders = new List<Order>();
        }
        public List<Order> GetAll()
        {
            return Orders;
        }
        public Order GetByCode(int code)
        {
            foreach (var item in Orders)
            {
                if(item.Code==code)
                    return item;
            }
            return null;
        }
        public void PostOrder(Order order)
        {
            Orders.Add(order);
        }
        public void PutOrder(int code, Order order)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].Code==code)
                    Orders[i]=order;
            }
        }
        public void DeleteOrder(int code)
        {
            foreach (var item in Orders)
            {
                if(item.Code==code)
                {
                    Orders.Remove(item);
                    return;
                }
            }
        }
    }
}
