using Optica.Entities;

namespace Optica.Services
{
    public class OrderService
    {
        public List<Order> GetAll() => DataContextManager.Data.Orders;

        public Order GetByCode(int code) => DataContextManager.Data.Orders.FirstOrDefault<Order>((order) => order.Code == code);

        public void PostOrder(Order order) => DataContextManager.Data.Orders.Add(order);

        public void PutOrder(int code, Order order)
        {
            int index = DataContextManager.Data.Orders.FindIndex(order => order.Code == code);
            if (index != -1)
            {
                DataContextManager.Data.Orders[index].EPayment = order.EPayment;
                DataContextManager.Data.Orders[index].ItemsNumber = order.ItemsNumber;
                DataContextManager.Data.Orders[index].UserId = order.UserId;
                DataContextManager.Data.Orders[index].ReceptionNumber = order.ReceptionNumber;
                DataContextManager.Data.Orders[index].EPlaceOrder = order.EPlaceOrder;
                DataContextManager.Data.Orders[index].TotalPrice = order.TotalPrice;
                DataContextManager.Data.Orders[index].OrederDate = order.OrederDate;
            }
        }
        public void DeleteOrder(int code) => DataContextManager.Data.Orders.Remove(GetByCode(code));
    }
}
