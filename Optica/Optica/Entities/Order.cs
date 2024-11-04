namespace Optica.Entities
{
    public enum Payment { CASH, CHEK, CREDITCARD }
    public enum PlaceOrder { SHOP, PHONE, SITE }
    public class Order
    {
        public int Code { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public Payment EPayment { get; set; }
        public string ReceptionNumber { get; set; }
        public DateTime OrederDate { get; set; }
        public int ItemsNumber { get; set; }
        public PlaceOrder EPlaceOrder { get; set; }
        List<Model> ModelsInOrder { get; set; }
        public Order(int code, string userId, double totalPrice, Payment ePayment, string receptionNumber, DateTime orederDate, int itemsNumber, PlaceOrder ePlaceOrder)
        {
            Code = code;
            UserId = userId;
            TotalPrice = totalPrice;
            EPayment = ePayment;
            ReceptionNumber = receptionNumber;
            OrederDate = orederDate;
            ItemsNumber = itemsNumber;
            EPlaceOrder = ePlaceOrder;
        }
    }
}
