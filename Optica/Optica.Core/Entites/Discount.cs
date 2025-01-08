using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Age { OLDER, BABY, CHILDREN }
    public enum SickFundName { MEUCHEDET, MACABI, LEUMIT, CLALIT, NULL }

    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int Id { get;private set; }
        public string SickFundId { get; set; }
        public string DiscountId { get; set; }
        public double DiscountAmount { get; set; }
        public string Rules { get; set; }
        public SickFundName ESickFundName { get; set; }
        public Age EAge { get; set; }

        //one to many - orders
        public List<Order> Orders { get; set; }
    }
}