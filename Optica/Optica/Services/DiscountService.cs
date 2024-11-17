using Optica.Entities;

namespace Optica.Services
{
    public class DiscountService
    {
        public List<Discount> GetAll() => DataContextManager.Data.Discounts;

        public Discount GetByDiscountId(string id) => DataContextManager.Data.Discounts.FirstOrDefault<Discount>(d => d.DiscountId == id);

        public void PostDiscount(Discount discount) => DataContextManager.Data.Discounts.Add(discount);

        public void PutDiscount(string id, Discount discount)
        {
            int index = DataContextManager.Data.Discounts.FindIndex(d => d.DiscountId == id);
            if (index != -1)
            {
                DataContextManager.Data.Discounts[index].DiscountAmount = discount.DiscountAmount;
                DataContextManager.Data.Discounts[index].Rules = discount.Rules;
                DataContextManager.Data.Discounts[index].EAge = discount.EAge;
                DataContextManager.Data.Discounts[index].ESickFundName = discount.ESickFundName;
                DataContextManager.Data.Discounts[index].SickFundId = discount.SickFundId;
            }
        }
        public void DeleteDiscount(string id) => DataContextManager.Data.Discounts.Remove(GetByDiscountId(id));
    }
}
