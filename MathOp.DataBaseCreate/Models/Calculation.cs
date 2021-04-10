using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MathOp.DataBaseCreate.Models
{
    public enum Operation
    {
        összeadás,kivonás, szorzás, osztás, hatványozás
    }

    public class Calculation
    {
        [Key]
        public int CalculationId { get; set; }
        public DateTime Created { get; set; }
        public double ANum { get; set; }
        public double BNum { get; set; }
        public Operation Operation { get; set; }
        public double Result { get; set; }
    }
}
