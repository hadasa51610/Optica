using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Age { OLDER, BABY, CHILDREN }
    public enum SickFundName { MEUCHEDET, MACABI, LEUMIT, CLALIT, NULL }
    public class Discount
    {
        public int Code { get; set; }
        public string SickFundId { get; set; }
        public string DiscountId { get; set; }
        public double DiscountAmount { get; set; }
        public string Rules { get; set; }
        public SickFundName ESickFundName { get; set; }
        public Age EAge { get; set; }
    }
}