using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Status { WORKER, CUSTOMER, MANAGER }
    public enum SickFund { MEUCHEDET, MACABI, LEUMIT, CLALIT, NULL }

    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime BirthDay { get; set; }
        public string Mail { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Status EStatus { get; set; }
        public SickFund ESickFund { get; set; }

        //one to one- check
        public int CheckId { get; set; }
        public Check Check { get; set; }

        //one to many - orders
        public List<Order> Orders { get; set; }
    }
}
