namespace Optica.Entities
{
    public enum Age { OLDER, BABY, CHILDREN }
    public enum SickFundName { MEUCHEDET, MACABI, LEUMIT, CLALIT, NULL }
    public class Discount
    {
        public int Code { get; set; }
        public string SickFundId { get; set; }
        public SickFundName ESickFundName { get; set; }
        public string DiscountId { get; set; }
        public double DiscountAmount { get; set; }
        public Age EAge { get; set; }
        public string Rules { get; set; }
    }
}
