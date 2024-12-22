using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Payment { CASH, CHEK, CREDITCARD }
    public enum PlaceOrder { SHOP, PHONE, SITE }
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public string ReceptionNumber { get; set; }
        public DateTime OrederDate { get; set; }
        public int ItemsNumber { get; set; }
        public PlaceOrder EPlaceOrder { get; set; }
        public Payment EPayment { get; set; }
    }
}