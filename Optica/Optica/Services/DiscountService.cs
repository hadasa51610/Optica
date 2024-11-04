using Optica.Entities;

namespace Optica.Services
{
    public class DiscountService
    {
        static List<Discount> Discounts { get; }
        public DiscountService() { }
        static DiscountService() { 
            Discounts = new List<Discount>();
        }
        public List<Discount> GetAll()
        {
            return Discounts;
        }
        public Discount GetByDiscountId(string id)
        {
            foreach (var discount in Discounts)
            {
                if(discount.DiscountId==id)
                    return discount;
            }
            return null;
        }
        public void PostDiscount(Discount discount)
        {
            Discounts.Add(discount);
        }
        public void PutDiscount(string id,Discount discount)
        {
            for (int i = 0; i < Discounts.Count; i++)
            {
                if (Discounts[i].DiscountId == id)
                    Discounts[i] = discount;
            }
        }
        public void DeleteDiscount(string id)
        {
            foreach (var discount in Discounts)
            {
                if (discount.DiscountId == id)
                {
                    Discounts.Remove(discount);
                    return;
                }
            }
        }
    }
}
