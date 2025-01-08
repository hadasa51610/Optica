using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.Entites
{
    public enum Sort { INCREASE, REDUCE, MULTIFOCAL }
    public enum Target { OLDER, BABY, CHILDREN }

    [Table("Model")]
    public class Model
    {
        [Key]
        public int Id { get;private set; }
        public string ModelId { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public double Scop { get; set; }
        public string Shape { get; set; }
        public Sort GlassSort { get; set; }
        public Target GlassTarget { get; set; }

        //many to many - orders
        public List<Order> Orders { get; set; }
    }
}