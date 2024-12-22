using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public class Check
    {
        public int Code { get; set; }
        public string UserId { get; set; }
        public string CheckId { get; set; }
        public string CheckerId { get; set; }
        public string Branch { get; set; }
        public DateTime CheckDate { get; set; }
        public bool NeedGlass { get; set; }
        public double Number { get; set; }
    }
}

