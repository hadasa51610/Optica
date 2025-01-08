using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Payment { CASH, CHEK, CREDITCARD }
    public enum PlaceOrder { SHOP, PHONE, SITE }

    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get;private set; }
        public string OrderCode { get; set; }
       
        public double TotalPrice { get; set; }
        public string ReceptionNumber { get; set; }
        public DateTime OrederDate { get; set; }
        public int ItemsNumber { get; set; }
        public PlaceOrder EPlaceOrder { get; set; }
        public Payment EPayment { get; set; }

        //one to many - user
        public int UserId { get; set; }
        public User User { get; set; }

        //one to many - discount
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        //many to many - models
        public List<Model> Models { get; set; }
    }
}