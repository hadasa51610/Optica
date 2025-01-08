using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    [Table("Check")]
    public class Check
    {
        [Key]
        public int Id { get;private set; }
        public string CheckId { get; set; }
        public string CheckerId { get; set; }
        public string Branch { get; set; }
        public DateTime CheckDate { get; set; }
        public bool NeedGlass { get; set; }
        public double Number { get; set; }

        //one to one - user
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

